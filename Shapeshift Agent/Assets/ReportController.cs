using UnityEngine;
using System.Collections;

public class ReportController : MonoBehaviour
{
    private GameObject previousLoadedReport;
    private SingletonData data;



    // Use this for initialization
    void Start () {
        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadReport()
    {
        if (previousLoadedReport) Destroy(previousLoadedReport);

        Sprite sprite = Resources.Load("report"+ data.CurrentSubjectNumber, typeof(Sprite)) as Sprite;
        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+ 9f);
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.parent = gameObject.transform;

    }

}
