using UnityEngine;
using System.Collections;

public class renderTestScript : MonoBehaviour
{

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
        data.CurrrentFace = new Face(
            new FacePart(PartType.LEFT_EYE, 0,0,0),
            new FacePart(PartType.RIGHT_EYE, 0, 0, 0),
            new FacePart(PartType.NOSE, 0, 0, 0),
            new FacePart(PartType.MOUTH, 0, 0, 0),
            new FacePart(PartType.CONTOUR, 1, 0, 0),
            new FacePart(PartType.HAIR, 0, 0, 0),
            HairColor.BLONDE, 
            SkinColor.WHITE
            );

  
    }



}
