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

    // Update is called once per frame
    void Update()
    {

    }
}
