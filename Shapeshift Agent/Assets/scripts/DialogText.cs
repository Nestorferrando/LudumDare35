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

    private enum State { NONE, DRAWALL, NEXT }
    private State currentState = State.NONE;



    public void Awake() {
        sound = gameObject.GetComponent<AudioSource>();
    }

    public void Start() {
        //generateBG();
        text = gameObject.GetComponent<Text>();
        string s = text.text;
        text.text = "";
        queuedText = processText(s);
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

    static IEnumerable<string> splitText(string str, int chunkSize) {
        return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
    }

    public Queue<string> processText(string text) {
        Queue<string> result = new Queue<string>();
        /*
        foreach (string s in splitText(text, charPerLine)) {
            result.Enqueue(s);
        }
        */
        string[] sep = { "[next]" };
        foreach (string s in text.Split(sep, StringSplitOptions.RemoveEmptyEntries)) {
            result.Enqueue(s);
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
