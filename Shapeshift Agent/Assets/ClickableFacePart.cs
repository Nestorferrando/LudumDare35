﻿using UnityEngine;
using System.Collections;

public class ClickableFacePart : MonoBehaviour
{

    public int partID;
    public PartType partType;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {

        switch (partType)

        {
            case PartType.CONTOUR:
                SingletonData.CurrrentFace = SingletonData.CurrrentFace.updateContour(new FacePart(PartType.CONTOUR, partID, 0, 0));
                break;
            case PartType.HAIR:
                SingletonData.CurrrentFace = SingletonData.CurrrentFace.updateHair(new FacePart(PartType.HAIR, partID, 0, 0));
                break;
        }
    }
}