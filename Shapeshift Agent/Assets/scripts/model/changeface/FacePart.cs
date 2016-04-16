using UnityEngine;
using System.Collections;


public enum PartType { CONTOUR,NOSE,MOUTH,HAIR,LEFT_EYE,RIGHT_EYE,SKIN };

public class FacePart
{

    private PartType type;
    private int ID;
    private int offsetX;
    private int offsetY;


    public FacePart(PartType type, int id, int offsetX, int offsetY)
    {
        this.type = type;
        ID = id;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }

    public int OffsetX
    {
        get { return offsetX; }
    }

    public int OffsetY
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
