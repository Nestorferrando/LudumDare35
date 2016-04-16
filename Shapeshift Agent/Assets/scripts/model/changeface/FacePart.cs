using UnityEngine;
using System.Collections;


public enum PartType { CONTOUR,NOSE,MOUTH,HAIR,LEFT_EYE,RIGHT_EYE,SKIN };

public class FacePart
{

    private PartType type;
    private int ID;
    private float offsetX;
    private float offsetY;


    public FacePart(PartType type, int id, float offsetX, float offsetY)
    {
        this.type = type;
        ID = id;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }

    public float OffsetX
    {
        get { return offsetX; }
    }

    public float OffsetY
    {
        get { return offsetY; }
    }

    public PartType Type
    {
        get { return type; }
    }

    public int Id
    {
        get { return ID; }
    }
}
