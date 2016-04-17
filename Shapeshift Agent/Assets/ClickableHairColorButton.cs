using UnityEngine;
using System.Collections;

public class ClickableHairColorButton : MonoBehaviour
{


    public HairColor color;
    private SingletonData data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();

	    SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.color = ColorUtils.getHairColor(color);
    }

    void OnMouseDown()
    {
        data.CurrrentFace = data.CurrrentFace.updateHairColor(color);
    }


// Update is called once per frame
void Update () {
	
	}
}
