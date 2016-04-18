using UnityEngine;
using System.Collections;

public class ClickableFaceColorButton : MonoBehaviour
{


    public SkinColor color;


	// Use this for initialization
	void Start () {


	    SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.color = ColorUtils.getSkinColor(color);
    }

    void OnMouseDown()
    {
        SingletonData.CurrentFace = SingletonData.CurrentFace.updateSkinColor(color);
        GetComponent<SpriteRenderer>().color = ColorUtils.getSkinColor(color);
    }


    void OnMouseUp()
    {
        Color c = ColorUtils.getSkinColor(color);
    }
    void OnMouseEnter()
    {
        Color c = ColorUtils.getSkinColor(color);
        GetComponent<SpriteRenderer>().color = new Color(c.r + 0.075f, c.g + 0.075f, c.b + 0.075f, 1);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = ColorUtils.getSkinColor(color);
    }
}
