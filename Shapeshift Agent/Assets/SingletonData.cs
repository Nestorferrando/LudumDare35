using UnityEngine;
using System.Collections;

public class SingletonData : MonoBehaviour
{

    private Face _CurrrentFace;
    private int currentInfiltrationLevel;
    private Target current;

	// Use this for initialization
	void Start ()
	{
	    _CurrrentFace = FacesDatabase.SampleFace;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Face CurrrentFace
    {
        get { return _CurrrentFace; }
        set { _CurrrentFace = value; }
    }

    public int CurrentInfiltrationLevel
    {
        get { return currentInfiltrationLevel; }
        set { currentInfiltrationLevel = value; }
    }
}
