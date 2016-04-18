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
        SingletonData.CurrentFace = SingletonData.CurrentFace.updateHairColor(color);
        GetComponent<SpriteRenderer>().color = ColorUtils.getHairColor(color);
    }


// Update is called once per frame
void Update () {
	
	}


    void OnMouseUp()
    {
        Color c = ColorUtils.getHairColor(color);
        GetComponent<SpriteRenderer>().color = new Color(c.r + 0.075f, c.g + 0.075f, c.b + 0.075f, 1);
    }
    void OnMouseEnter()
    {
        Color c = ColorUtils.getHairColor(color);
        GetComponent<SpriteRenderer>().color = new Color(c.r+0.075f, c.g + 0.075f, c.b + 0.075f, 1);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = ColorUtils.getHairColor(color);
    }


}
