using System;
using UnityEngine;
using System.Collections;

public class BlackLayerController : MonoBehaviour
{

    private Boolean layerActive = false;


    public bool LayerActive
    {
        get { return layerActive; }
        set { layerActive = value; }
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(layerActive)
        {
           GetComponent<SpriteRenderer>().color= new Color(1,1,1, Math.Min(1, GetComponent<SpriteRenderer>().color.a+0.02f));
        }
        else
	    {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Math.Max(0, GetComponent<SpriteRenderer>().color.a - 0.02f));
        }

	}
}
