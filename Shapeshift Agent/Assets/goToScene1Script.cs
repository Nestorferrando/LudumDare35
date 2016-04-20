using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goToScene1Script : MonoBehaviour
{

    public String targetScene = "gameStage1";

    // Use this for initialization
    void Start ()
    {
        Control.missionIndex = 0;
        SingletonData.CurrentInfiltrationLevel = 0;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
     
            GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 1, 1);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
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
