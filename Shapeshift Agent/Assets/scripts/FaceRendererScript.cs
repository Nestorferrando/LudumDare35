using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FaceRendererScript : MonoBehaviour {



    /*
    void OnMouseUp()
    {
        Debug.Log("mouse up lalala");
    }
    */

    private SingletonData data;

    void Start()
    {
     
        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();


    }

    private Face PreviousFace;

    // Update is called once per frame
    void Update()
    {
        if (PreviousFace != data.CurrrentFace)
        {
            PreviousFace = data.CurrrentFace;

            renderFace(data.CurrrentFace);
        }
    }

    private void renderFace(Face face)

    {
        removeChildren();

        Sprite sprite = Resources.Load("face"+ face.Contour.Id, typeof(Sprite)) as Sprite;
        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.25f);
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.color = ColorUtils.getSkinColor(face.SkinColor);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("face" + face.Contour.Id+"_back", typeof(Sprite)) as Sprite;
        obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.color = ColorUtils.getSkinColor(face.SkinColor);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("clothes", typeof(Sprite)) as Sprite;
        obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.09f);
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("hair" + face.Hair.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.color = ColorUtils.getHairColor(face.HairColor);
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("left_eye" + face.LeftEye.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("right_eye" + face.RightEye.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("mouth" + face.Mouth.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.4f);
        rend.sprite = sprite;
        obj.transform.parent = gameObject.transform;

    }



    private void removeChildren()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }




}
