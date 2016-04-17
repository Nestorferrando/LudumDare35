using UnityEngine;
using System.Collections;

public class ClickableHairColorButton : MonoBehaviour
{


    public HairColor color;
	// Use this for initialization
	void Start () {

	    SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.color = ColorUtils.getHairColor(color);
    }

    void OnMouseDown()
    {
        SingletonData.CurrrentFace = SingletonData.CurrrentFace.updateHairColor(color);
    }


// Update is called once per frame
void Update () {
	
	}
}
