using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogText : MonoBehaviour {
    [Range(.01f, .1f)]
    public float wait = .005f;

    private string str;
    private AudioSource sound;
    private Queue<string> queuedText;
    private Text text;
    private string lastPeak = "";
    private string missionText = "";
    private const int max_lines = 3;

    private enum State { NONE, DRAWALL, NEXT, QUESTION }
    private State currentState = State.NONE;



    public void Awake() {
        sound = gameObject.GetComponent<AudioSource>();
    }

    public void Start() {
        //generateBG();
        text = gameObject.GetComponent<Text>();
        string s = text.text;
        text.text = "";
        missionText = Resources.Load<TextAsset>("SceneText/mission1").text;
        queuedText = processText(missionText);
        displayNextDialog();
    }



    public void generateBG() { // TODO: use img
        Rect r = gameObject.GetComponent<RectTransform>().rect;
        GameObject g = new GameObject("DialogBG");
        SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
        Texture2D tex = new Texture2D(1, 1);
        Sprite s = Sprite.Create(tex, new Rect(0, 0, 2, 2), Vector2.zero, 1);
        sr.sprite = s;
    }


    string[] currentTags = { "FAILURE", "ALWAYS", "SILLY" };
    public bool checkTags(string tag) {
        foreach (string t in currentTags) {
            //Debug.Log(t + " =?= " + tag + " | " + t==tag + " | " + t.Length + " " + tag.Length);
            if (t == tag) {
                return true;
            } 
        }
        return false;
    }

    public Queue<string> processText(string text) {
        Queue<string> result = new Queue<string>();

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
                    result.Enqueue(t);
                }

            }
        }

        return result;
        
    }

   

    public void displayNextDialog() {
        StopAllCoroutines();
        text.text = "";
        if (queuedText.Count > 0) {
            lastPeak = queuedText.Dequeue();
            StartCoroutine(animateText(lastPeak));
        } else if (queuedText.Count == 0) {
            currentState = State.NONE;
        }
    }

    public void displayAllDialog() {
        StopAllCoroutines();
        text.text = lastPeak;
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            //displayNextDialog();
            //mouse0pressed = true;
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
                displayQuestionDialog();

            case State.NONE:
            default:
                break;
        }

        Debug.Log(currentState);
    }

    private IEnumerator animateText(string strComplete) {
        currentState = State.DRAWALL;
        int i = 0;
        str = "";
        while (i < strComplete.Length) {
            str += strComplete[i++];
            drawNewText(str, strComplete[i - 1], i);
            yield return new WaitForSeconds(wait);
        }

        currentState = State.NEXT;
    }

    private void drawEverything(string completeText) {
        StopAllCoroutines();
        text.text = completeText;
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
}
