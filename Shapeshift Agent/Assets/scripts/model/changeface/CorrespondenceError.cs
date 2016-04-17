using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class CorrespondenceError
{
    private float totalError;
    private float displacementError;
    private PartType worstDisplacedPart;
    private int badSelectedShapes;
    private PartType partWithWorstShape;


    public CorrespondenceError(float totalError, float displacementError, PartType worstDisplacedPart, int badSelectedShapes, PartType partWithWorstShape)
    {
        this.totalError = totalError;
        this.displacementError = displacementError;
        this.worstDisplacedPart = worstDisplacedPart;
        this.badSelectedShapes = badSelectedShapes;
        this.partWithWorstShape = partWithWorstShape;
    }

    public float TotalError
    {
        get { return totalError; }
    }

    public float DisplacementError
    {
        get { return displacementError; }
    }

    public PartType WorstDisplacedPart
    {
        get { return worstDisplacedPart; }
    }

    public float BadSelectedShapes
    {
        get { return badSelectedShapes; }
    }

    public PartType PartWithWorstShape
    {
        get { return partWithWorstShape; }
    }
}

