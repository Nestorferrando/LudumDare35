using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogText : MonoBehaviour {
    [Range(.01f, .1f)]
    public float wait = .005f;
    public static List<string> currentTags = new List<string>();


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

    public void Awake() {
        sound = gameObject.GetComponent<AudioSource>();
        currentQuestion.tags = new List<string>();
        currentQuestion.answers = new List<string>();
    }

    public void Start() {
        //generateBG();
        currentTags.Add("ALWAYS");
        text = gameObject.GetComponent<Text>();
        string s = text.text;
        text.text = "";
        missionText = Resources.Load<TextAsset>("SceneText/mission1").text;
        run = processText();
    }



    private void generateBG() { // TODO: use img
        Rect r = gameObject.GetComponent<RectTransform>().rect;
        GameObject g = new GameObject("DialogBG");
        SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
        Texture2D tex = new Texture2D(1, 1);
        Sprite s = Sprite.Create(tex, new Rect(0, 0, 2, 2), Vector2.zero, 1);
        sr.sprite = s;
    }


    private bool checkTags(string tag) {
        foreach (string t in currentTags) {
            //Debug.Log(t + " =?= " + tag + " | " + t==tag + " | " + t.Length + " " + tag.Length);
            if (t == tag) {
                return true;
            } 
        }
        return false;
    }

    private string preprocessText(string text) {
        string[] lines = text.Split('\n');
        bool questionFound = false;
        string res = "";

        for (int i = 0; i < lines.Length; ++i) {
            //Debug.Log("lines["+i+"] = " + lines[i] + " " + lines[i].Length);
            if (lines[i].Substring(0, lines[i].Length-1) == "[question]") {
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
                string tag = s.Substring(1, index-1);
                string info = s.Substring(index+1);
                //Debug.Log("tag = " + tag + " question = " + question);
                questions.Last().answers.Add(info);
                questions.Last().tags.Add(tag);
                //Debug.Log("> tag = " + questions.Last().tags.Last() + " question = " + questions.Last().questions.Last());
            } else {
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
            string tagFound = lineText[1].Substring(0, lineText[1].Length-1);

            if (checkTags(tagFound)) {

                string res = "";
                for (int i = 2; i < lineText.Length; ++i) {
                    res += lineText[i] + '\n';
                }

                foreach (string t in res.Split(sep_nextLine, StringSplitOptions.RemoveEmptyEntries)) {
                    queuedText.Enqueue(t);
                    Debug.Log(t);
                    yield return t;
                }
            }
        }

        yield break;
    }

   

    private void displayNextDialog() {
        StopAllCoroutines();
        text.text = "";
        run.MoveNext();
        
        
        if (queuedText.Count > 0) {
            lastPeak = queuedText.Dequeue();

            int i = lastPeak.IndexOf("[question]");
            if (i > 0) {
                currentState = State.QUESTION;
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
            
        } else if (queuedText.Count == 0) {
            currentState = State.NONE;
        }
    }

    private void displayQuestionDialog(int questionNumber) {
        currentQuestion = questions.ElementAt(questionNumber);
        String s = "";
        for (int i = 0; i < currentQuestion.answers.Count; ++i) {
            s += currentQuestion.answers[i] + "\n";
        }
        StartCoroutine(animateText(s));
    }

    private void displayAllDialog() {
        if (!lastPeak.Contains("[question]")) {
            StopAllCoroutines();
            text.text = lastPeak;
        }
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            handleDialog();
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
            if (i%3 == 0)
                sound.Play();
        }
        //}
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
        currentTags.Add(currentQuestion.tags.ElementAt(n+1));
        currentState = State.NEXT;
        handleDialog();
    }
}
