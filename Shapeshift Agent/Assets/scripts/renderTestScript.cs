using UnityEngine;
using System.Collections;

public class renderTestScript : MonoBehaviour
{

    private FaceRendererScript faceRend;

	// Use this for initialization
	void Start () {
        faceRend = GameObject.Find("bigFaceRenderer").GetComponent<FaceRendererScript>();


    }
	
	// Update is called once per frame
	void Update () {



    }


    void OnMouseDown()
    {
        Face face= new Face(
            new FacePart(PartType.LEFT_EYE, 0,0,0),
            new FacePart(PartType.RIGHT_EYE, 0, 0, 0),
            new FacePart(PartType.NOSE, 0, 0, 0),
            new FacePart(PartType.MOUTH, 0, 0, 0),
            new FacePart(PartType.CONTOUR, 0, 0, 0),
            new FacePart(PartType.HAIR, 0, 0, 0),
            HairColor.BLONDE, 
            SkinColor.WHITE
            );

        faceRend.renderFace(face);

    }



}
