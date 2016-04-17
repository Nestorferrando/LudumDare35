using UnityEngine;
using System.Collections;

public class ClickableFacePart : MonoBehaviour
{

    public int partID;
    public PartType partType;
    private SingletonData data;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {

        switch (partType)

        {
            case PartType.CONTOUR:
                data.CurrrentFace = data.CurrrentFace.updateContour(new FacePart(PartType.CONTOUR, partID, 0, 0));
                break;
            case PartType.HAIR:
                data.CurrrentFace = data.CurrrentFace.updateHair(new FacePart(PartType.HAIR, partID, 0, 0));
                break;
        }
    }
}
