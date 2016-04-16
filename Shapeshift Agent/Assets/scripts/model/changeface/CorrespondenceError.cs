using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class CorrespondenceError
{
    private float totalError;

    private float displacementError;
    private PartType worstDisplacedPart;

    private float shapeError;
    private PartType partWithWorstShape;


    public CorrespondenceError(float totalError, float displacementError, PartType worstDisplacedPart, float shapeError, PartType partWithWorstShape)
    {
        this.totalError = totalError;
        this.displacementError = displacementError;
        this.worstDisplacedPart = worstDisplacedPart;
        this.shapeError = shapeError;
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

    public float ShapeError
    {
        get { return shapeError; }
    }

    public PartType PartWithWorstShape
    {
        get { return partWithWorstShape; }
    }
}

