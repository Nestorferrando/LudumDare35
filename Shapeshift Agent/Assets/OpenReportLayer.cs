using UnityEngine;
using System.Collections;

public class OpenReportLayer : MonoBehaviour {


    private GameObject reportLayer;
    private SingletonData data;

    // Use this for initialization
    void Start()
    {
        reportLayer = GameObject.Find("report_layer");

    }


    void OnMouseDown()

    {
        reportLayer.transform.localScale = new Vector3(1, 1, 1);
        reportLayer.GetComponent<ReportController>().loadReport();

        GetComponent<AudioSource>().Play();

    }

    void OnMouseEnter()
    {
            GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f,1 , 1);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
