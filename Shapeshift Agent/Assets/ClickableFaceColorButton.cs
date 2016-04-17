using UnityEngine;
using System.Collections;

public class ClickableFaceColorButton : MonoBehaviour
{


    public SkinColor color;
    private SingletonData data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();

	    SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.color = ColorUtils.getSkinColor(color);
    }

    void OnMouseDown()
    {
        data.CurrrentFace = data.CurrrentFace.updateSkinColor(color);
    }


// Update is called once per frame
void Update () {
	
	}
}
