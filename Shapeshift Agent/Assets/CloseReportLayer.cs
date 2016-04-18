using UnityEngine;
using System.Collections;

public class CloseReportLayer : MonoBehaviour
{



    private GameObject reportLayer;


	// Use this for initialization
	void Start () {
        reportLayer= GameObject.Find("report_layer");



    }
    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 1, 1);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    void OnMouseDown()

    {
        reportLayer.transform.localScale = new Vector3(0, 0, 0);
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
