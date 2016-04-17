using UnityEngine;
using System.Collections;

public class ReportController : MonoBehaviour
{
    private GameObject previousLoadedReport;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if (previousLoadedReport != null)
	    {
	        previousLoadedReport.transform.eulerAngles = new Vector3(0, 0,
	            previousLoadedReport.transform.eulerAngles.z*0.85f);
	        previousLoadedReport.transform.position = new Vector3(0, previousLoadedReport.transform.position.y*0.85f,
	            previousLoadedReport.transform.position.z);
	    }
	}

    public void loadReport()
    {
        if (previousLoadedReport) Destroy(previousLoadedReport);

        Sprite sprite = Resources.Load("report"+ SingletonData.CurrentInfiltrationLevel, typeof(Sprite)) as Sprite;
        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y+ 10, transform.position.z+ 9f);
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.transform.eulerAngles  = new Vector3(0,0,60f);
        obj.transform.parent = gameObject.transform;
        rend.sortingOrder = 2;
        previousLoadedReport = obj;
    }

}
