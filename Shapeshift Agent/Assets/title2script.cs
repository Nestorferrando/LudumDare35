using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class title2script : MonoBehaviour {

    private Text text;

    private String targetText = " A noir infiltration game \n " +
                                "Subject: Amanda lalala \n " +
                                "Range: Senior Spy \n " +
                                "Current status: weak, suspension quite probable before next month " +
                                "\n \n \n click to continue...";
    private int letterCount = 0;

    // Use this for initialization
    void Start () {

        text = gameObject.GetComponent<Text>();

        text.text = "";
        Invoke("addLetter",1.5f);

    }
	
	// Update is called once per frame
	void Update () {
    }


    private void addLetter()
    {
        letterCount++;

        char nextLetter = targetText.Substring(0, 1).ToCharArray()[0];
        text.text = text.text + targetText.Substring(0, 1);
        targetText = targetText.Substring(1, targetText.Length-1);

        if (targetText.Length > 0)
        {
            if (nextLetter == '\n')
                Invoke("addLetter", 0.3f);
            else
            Invoke("addLetter",0.065f);
        }

        AudioSource sound = GetComponent<AudioSource>();
        if (sound != null && nextLetter != '\n')
        {
            sound.pitch = Random.Range(.9f, 1.1f);
            if (letterCount % 2 == 0)
                sound.Play();
        }

    }

}
