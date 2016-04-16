using UnityEngine;
using System.Collections;


public enum PartType { CONTOUR,NOSE,MOUTH,HAIR,LEFT_EYE,RIGHT_EYE };

public class FacePart
{

    private PartType ID;
    private int offsetX;
    private int offsetY;


    public FacePart(PartType id, int offsetX, int offsetY)
    {
        ID = id;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }


    public PartType Id
    {
        get { return ID; }
    }

    public int OffsetX
    {
        get { return offsetX; }
    }

    public int OffsetY
    {
        get { return offsetY; }
    }
}
