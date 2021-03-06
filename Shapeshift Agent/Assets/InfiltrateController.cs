﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InfiltrateController : MonoBehaviour
{
    private AudioSource cameraAudioSource=null;

	// Use this for initialization
	void Start ()
	{
	   

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (cameraAudioSource != null) cameraAudioSource.volume = cameraAudioSource.volume*0.9f;

	}

    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GameObject.Find("black_layer").GetComponent<BlackLayerController>().LayerActive = true;
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Invoke("goToScene3",2.0f);
       
    }

    private void goToScene3()
    {
        SceneManager.LoadScene("gameStage1");
    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 1, 1);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

}
