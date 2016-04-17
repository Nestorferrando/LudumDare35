using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FaceRendererScript : MonoBehaviour {





    private SingletonData data;
    private Face PreviousFace;
    public float scale = 0.5f;


    void Start()
    {
     
        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();
    }




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
        obj.transform.localScale = new Vector3(scale, scale, 1);
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.color = ColorUtils.getSkinColor(face.SkinColor);
        obj.transform.parent = gameObject.transform;

        float height = sprite.bounds.size.y;
        float width = sprite.bounds.size.x;

        sprite = Resources.Load("face" + face.Contour.Id+"_back", typeof(Sprite)) as Sprite;
        obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.color = ColorUtils.getSkinColor(face.SkinColor);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("clothes", typeof(Sprite)) as Sprite;
        obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.09f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("hair" + face.Hair.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.color = ColorUtils.getHairColor(face.HairColor);
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("left_eye" + face.LeftEye.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.position = new Vector3(transform.position.x+face.LeftEye.OffsetX*scale / width, transform.position.y + face.LeftEye.OffsetY * scale / height, -0.3f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("right_eye" + face.RightEye.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.position = new Vector3(transform.position.x + face.RightEye.OffsetX * scale / width, transform.position.y + face.RightEye.OffsetY * scale / height, -0.3f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("mouth" + face.Mouth.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        obj.transform.position = new Vector3(transform.position.x + face.Mouth.OffsetX * scale / width, transform.position.y + face.Mouth.OffsetY * scale / height, -0.4f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        rend.sprite = sprite;
        obj.transform.parent = gameObject.transform;

        sprite = Resources.Load("nose" + face.Nose.Id, typeof(Sprite)) as Sprite;
        obj = new GameObject();
        rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        obj.transform.position = new Vector3(transform.position.x + face.Nose.OffsetX * scale / width, transform.position.y + face.Nose.OffsetY * scale / height, -0.4f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
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
