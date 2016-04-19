using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goToScene1ScriptNoBlue : MonoBehaviour
{

    public String targetScene = "gameStage1";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        if (Time.realtimeSinceStartup > 2.0f)
        {
            if (GetComponent<AudioSource>()!=null)
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(targetScene);

        }
       
    }

}
