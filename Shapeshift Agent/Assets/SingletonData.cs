using UnityEngine;
using System.Collections;

public class SingletonData
{

    private static Face _CurrentFace = FacesDatabase.Subject5;
    private static int currentInfiltrationLevel;
    private static Target _currentTarget = new Target(TargetConfidence.FOUR);



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
}
