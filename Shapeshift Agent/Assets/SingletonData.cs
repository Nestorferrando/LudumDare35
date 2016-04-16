using UnityEngine;
using System.Collections;

public class SingletonData : MonoBehaviour
{

    private Face _CurrrentFace;

	// Use this for initialization
	void Start () {
	 _CurrrentFace = new Face(
            new FacePart(PartType.LEFT_EYE, 0, 0, 0),
            new FacePart(PartType.RIGHT_EYE, 0, 0, 0),
            new FacePart(PartType.NOSE, 0, 0, 0),
            new FacePart(PartType.MOUTH, 0, 0, 0),
            new FacePart(PartType.CONTOUR, 0, 0, 0),
            new FacePart(PartType.HAIR, 0, 0, 0),
            HairColor.BLONDE,
            SkinColor.WHITE
            );
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public Face CurrrentFace
    {
        get { return _CurrrentFace; }
        set { _CurrrentFace = value; }
    }


}
