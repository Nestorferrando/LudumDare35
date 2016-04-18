using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class title1script : MonoBehaviour {

    private Text text;

    private String targetText = " THE OTHERS";
    private int letterCount = 0;

    // Use this for initialization
    void Start () {

        text = gameObject.GetComponent<Text>();

        text.text = "";
        addLetter();

    }
	
	// Update is called once per frame
	void Update () {
    }




    private void drawNewText(string str, char c, int i)
    {
        text.text = str;
        //if (c != ' ' && c != '\n' && c != '\t') {
        AudioSource sound = GetComponent<AudioSource>();

        if (sound != null)
        {
            sound.pitch = Random.Range(.9f, 1.1f);
            if (letterCount % 5 == 0)
                sound.Play();
        }
        //}
    }


    private void addLetter()
    {
        letterCount++;
        text.text = text.text + targetText.Substring(0, 1);
        targetText = targetText.Substring(1, targetText.Length-1);

        if (targetText.Length>0) Invoke("addLetter",0.065f);

        AudioSource sound = GetComponent<AudioSource>();
        if (sound != null)
        {
            sound.pitch = Random.Range(.9f, 1.1f);
            if (letterCount % 2 == 0)
                sound.Play();
        }

    }

}
