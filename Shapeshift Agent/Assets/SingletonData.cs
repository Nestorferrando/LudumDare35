using UnityEngine;
using System.Collections;

public class SingletonData
{

    private static Face _CurrrentFace = FacesDatabase.Subject5;
    private static int currentInfiltrationLevel;
    private static Target _currentTarget = new Target(TargetConfidence.FOUR);



    public static Face CurrrentFace
    {
        get { return _CurrrentFace; }
        set { _CurrrentFace = value; }
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
