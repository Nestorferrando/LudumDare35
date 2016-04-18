using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogText : MonoBehaviour {
    [Range(.0001f, .1f)]
    public float wait = .005f;

    private string str;
    private AudioSource sound;
    private Queue<string> queuedText = new Queue<string>();
    private Text text;
    private string lastPeak = "";
    private string missionText = "";
    private const int max_lines = 3;
    private Question currentQuestion;
    private IEnumerator run;
    private enum State { NONE, DRAWALL, NEXT, QUESTION }
    private State currentState = State.NEXT;
    private struct Question {
        public List<string> tags;
        public List<string> answers;
    };
    private List<Question> questions = new List<Question>();
    private int questionIndex = -1;
    private GameObject dialogueCanvas;
    private Button[] buttons = new Button[4];

    public void Awake() {
        sound = gameObject.GetComponent<AudioSource>();
        currentQuestion.tags = new List<string>();
        currentQuestion.answers = new List<string>();
        
        dialogueCanvas = GameObject.Find("DialogueCanvas");
        buttons[0] = dialogueCanvas.transform.FindChild("Button0").GetComponent<Button>();
        buttons[1] = dialogueCanvas.transform.FindChild("Button1").GetComponent<Button>();
        buttons[2] = dialogueCanvas.transform.FindChild("Button2").GetComponent<Button>();
        buttons[3] = dialogueCanvas.transform.FindChild("Button3").GetComponent<Button>();

        disableButtons();

        if (Control.infiltration) {
            GameObject.Find("TargetTrust").SetActive(true);
            GameObject.Find("bg").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bg");
        } else {
            GameObject.Find("TargetTrust").SetActive(false);
            GameObject.Find("bg").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bg-noir-1");
        }
    }

    public void Start() {
        //generateBG();
        Control.currentTags.Add("ALWAYS");
        text = gameObject.GetComponent<Text>();
        text.text = "";
        Debug.Log(Control.currentMission());
        missionText = Resources.Load<TextAsset>("SceneText/" + Control.currentMission()).text;
        run = processText();
        displayNextDialog();
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            handleDialog();
        }
    }

    private void displayNextDialog() {
        StopAllCoroutines();
        text.text = "";
        if (!run.MoveNext()) {
            currentState = State.NONE;
            launchEmptyConversationAction();
        }


        if (queuedText.Count > 0) {
            lastPeak = queuedText.Dequeue();

            int i = lastPeak.IndexOf("[question]");
            if (i > 0) {
                currentState = State.QUESTION;
                enableButtons();
                string n_str = "";
                i += "[question]".Length;
                while (i < lastPeak.Length && lastPeak[i] != '\n') {
                    n_str += lastPeak[i++];
                }
                int n = Convert.ToInt32(n_str);
                displayQuestionDialog(n);
            }
            else {
                currentState = State.DRAWALL;
                StartCoroutine(animateText(lastPeak));
            }
        }
    }

    private void displayQuestionDialog(int questionNumber) {
        currentQuestion = questions.ElementAt(questionNumber);
        String s = "";
        for (int i = 0; i < currentQuestion.answers.Count; ++i) {
            s += currentQuestion.answers[i] + "\n";
            if (i != 0) {
                RectTransform r = buttons[i-1].gameObject.GetComponent<RectTransform>();
                float originalWidth = r.sizeDelta.x;
                float width = currentQuestion.answers[i].Length * 12.5f;
                //rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, top);
                //r.sizeDelta = new Vector2(width, r.rect.height);
                //r.position = new Vector2(r.position.x - originalWidth - width, r.position.y);
            }
        }
        StartCoroutine(animateText(s));
    }

    private void displayAllDialog() {
        if (!lastPeak.Contains("[question]")) {
            StopAllCoroutines();
            text.text = lastPeak;
        }
    }

    private void handleDialog() {
        switch (currentState) {
            case State.DRAWALL:
                currentState = State.NEXT;
                displayAllDialog();
                break;
            case State.NEXT:
                currentState = State.DRAWALL;
                displayNextDialog();
                break;
            case State.QUESTION:
                //displayQuestionDialog();
                break;
            case State.NONE:
            default:
                break;
        }

        //Debug.Log(currentState);
    }

    private IEnumerator animateText(string strComplete) {
        int i = 0;
        str = "";
        while (i < strComplete.Length) {
            str += strComplete[i++];
            drawNewText(str, strComplete[i - 1], i);
            yield return new WaitForSeconds(wait);
        }

        if (currentState != State.QUESTION) {
            currentState = State.NEXT;
        } else {
            
        }
    }

    private void drawNewText(string str, char c, int i) {
        text.text = str;
        //if (c != ' ' && c != '\n' && c != '\t') {
        if (sound != null) {
            sound.pitch = Random.Range(.9f, 1.1f);
            if (i%5 == 0)
                sound.Play();
        }
        //}
    }










    private bool checkTags(string tag) {
        if (tag[0] != '!') {
            foreach (string t in Control.currentTags) {
                //Debug.Log(t + " =?= " + tag + " | " + t==tag + " | " + t.Length + " " + tag.Length);
                if (t == tag) {
                    return true;
                }
            }
            return false;
        }
        else {
            tag = tag.Substring(1);
            foreach (string t in Control.currentTags) {
                //Debug.Log(t + " =?= " + tag + " | " + t==tag + " | " + t.Length + " " + tag.Length);
                if (t == tag) {
                    return false;
                }
            }
            return true;
        }
    }

    private string preprocessText(string text) {
        string[] lines = text.Split('\n');
        bool questionFound = false;
        string res = "";

        for (int i = 0; i < lines.Length; ++i) {
            //Debug.Log("lines["+i+"] = " + lines[i] + " " + lines[i].Length);
            if (lines[i].Substring(0, lines[i].Length - 1) == "[question]") {
                questionFound = true;
                Question q = new Question();
                q.answers = new List<string>();
                q.tags = new List<string>();
                questions.Add(q);
                res += "[question]" + ++questionIndex + "\n";
                continue;
            }
            else if (lines[i].Substring(0, lines[i].Length - 1) == "[endquestion]") {
                questionFound = false;
                continue;
            }

            if (questionFound) {
                string s = lines[i];
                int index = s.IndexOf(']');
                string tag = s.Substring(1, index - 1);
                string info = s.Substring(index + 1);
                //Debug.Log("tag = " + tag + " question = " + question);
                questions.Last().answers.Add(info);
                questions.Last().tags.Add(tag);
                //Debug.Log("> tag = " + questions.Last().tags.Last() + " question = " + questions.Last().questions.Last());
            }
            else {
                res += lines[i] + '\n';
            }

        }

        return res;
    }

    private IEnumerator processText() {
        string text = missionText;
        text = preprocessText(text);

        //Debug.Log("text = " + text);

        string[] sep_tag = { "[TAG]" };
        string[] sep_nextLine = { "[next]" };
        foreach (string s in text.Split(sep_tag, StringSplitOptions.RemoveEmptyEntries)) {
            string[] lineText = s.Split('\n');
            string tagFound = lineText[1].Substring(0, lineText[1].Length - 1);

            if (checkTags(tagFound)) {

                string res = "";
                for (int i = 2; i < lineText.Length; ++i) {
                    res += lineText[i] + '\n';
                }

                foreach (string t in res.Split(sep_nextLine, StringSplitOptions.RemoveEmptyEntries)) {
                    queuedText.Enqueue(t);
                    yield return null;
                }
            }
        }

        yield break;
    }












    private void disableButtons() {
        dialogueCanvas.SetActive(false);
    }

    private void enableButtons() {
        dialogueCanvas.SetActive(true);
    }

    public void DialogButton0Pressed() {
        answerSelected(0);
    }

    public void DialogButton1Pressed() {
        answerSelected(1);
    }

    public void DialogButton2Pressed() {
        answerSelected(2);
    }

    public void DialogButton3Pressed() {
        answerSelected(3);
    }

    private void answerSelected(int n) {
        Debug.Log(n + " button selected!");
        Debug.Log(currentQuestion.tags.ElementAt(n+1));
        Control.currentTags.Add(currentQuestion.tags.ElementAt(n+1));
        currentState = State.NEXT;
        disableButtons();
        handleDialog();
    }

    private void launchEmptyConversationAction() {
        Debug.Log("NEXT SCENE!");
        StartCoroutine(fadeIn());
    }

    private void goToNextScene() {
        if (Control.infiltration) {
            Control.infiltration = false;
            // if trust is nice:
            Control.nextMission();
            SceneManager.LoadScene("gameStage1");
        } else {
            SceneManager.LoadScene("gameStage2");
        }
    }

    private IEnumerator fadeIn() {
        SpriteRenderer sr = GameObject.Find("black_layer").GetComponent<SpriteRenderer>();
        float a = sr.color.a;
        while (a < 1f) {
            a += 0.75f * Time.deltaTime;
            sr.color = new Vector4(sr.color.r, sr.color.g, sr.color.b, a);

            Camera.main.GetComponent<AudioSource>().volume -= a/4f;
            yield return new WaitForSeconds(0.01f);
        }
        goToNextScene();    
    }
}
