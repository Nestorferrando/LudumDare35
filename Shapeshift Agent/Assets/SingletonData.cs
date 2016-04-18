using UnityEngine;
using System.Collections;

public class SingletonData
{

    private static Face _CurrentFace = FacesDatabase.InitialFace;
    private static int currentInfiltrationLevel;
    private static Target _currentTarget = new Target(TargetTrust.FOUR,PartType.HAIR);



    public static Face CurrentFace
    {
        get { return _CurrentFace; }
        set { _CurrentFace = value; }
    }

    public static int CurrentInfiltrationLevel
    {
        get { return currentInfiltrationLevel; }
        set { currentInfiltrationLevel = value; }
    }


    public static Target CurrentTarget
    {
        get { return _currentTarget; }
        set { _currentTarget = value; }
    }

    public static void updateTargetTrustToInitial()
    {
        CorrespondenceError error= CorrespondenceUtils.GetFaceError(
            FacesDatabase.getFaceFromLevel(currentInfiltrationLevel), _CurrentFace);
        int trust = (int)Mathf.Max(0, Mathf.Ceil(5 - error.TotalError));
        if (error.DisplacementError > error.BadSelectedShapes)
        {
            _currentTarget = new Target((TargetTrust) trust, error.WorstDisplacedPart);
        }
        else
        {
            _currentTarget = new Target((TargetTrust)trust, error.PartWithWorstShape);
        }
    }

}
