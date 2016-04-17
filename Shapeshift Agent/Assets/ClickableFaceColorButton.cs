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
        SingletonData.CurrrentFace = SingletonData.CurrrentFace.updateSkinColor(color);
    }


// Update is called once per frame
void Update () {
	
	}
}
