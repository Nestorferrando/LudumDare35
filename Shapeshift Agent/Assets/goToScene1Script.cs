using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goToScene1Script : MonoBehaviour
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
        if (Time.realtimeSinceStartup>3.0f)
        SceneManager.LoadScene(targetScene);
    }

}
