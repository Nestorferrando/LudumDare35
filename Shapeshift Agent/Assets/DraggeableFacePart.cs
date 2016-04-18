using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel.Design;

public class DraggeableFacePart : MonoBehaviour
{
    private GameObject bigFaceRenderer;

    public int partID;
    public PartType partType;
    private GameObject obj = null;


    // Use this for initialization
    void Start()
    {
        bigFaceRenderer = GameObject.Find("bigFaceRenderer");
    }

    // Update is called once per frame
    void Update()
    {

    }


    private String geFileName()

    {
        switch (partType)

        {

            case PartType.LEFT_EYE:
                return "left_eye" + partID;
            case PartType.RIGHT_EYE:
                return "right_eye" + partID;
            case PartType.MOUTH:
                return "mouth" + partID;
            case PartType.NOSE:
                return "nose" + partID;
        }
        return null;
    }



void OnMouseUp()
{

    if (obj != null)
    {
        Destroy(obj);
        obj = null;
    }

    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    float differenceX =     bigFaceRenderer.transform.position.x - mousePos.x;
    float differenceY = bigFaceRenderer.transform.position.y - mousePos.y;

    if (Math.Abs(differenceX) < 2 && Math.Abs(differenceY) < 3)

    {
        Vector2 scale = getDisplacementScale();
            switch (partType)

            {
                case PartType.LEFT_EYE:
                    SingletonData.CurrentFace= SingletonData.CurrentFace.updateLeftEye(new FacePart(PartType.LEFT_EYE, partID, -differenceX*scale.x, -differenceY*scale.y));
                    break;
                case PartType.RIGHT_EYE:
                    SingletonData.CurrentFace = SingletonData.CurrentFace.updateRightEye(new FacePart(PartType.RIGHT_EYE, partID, -differenceX * scale.x, -differenceY * scale.y));
                    break;
                case PartType.MOUTH:
                    SingletonData.CurrentFace = SingletonData.CurrentFace.updateMouth(new FacePart(PartType.MOUTH, partID, -differenceX * scale.x, -differenceY * scale.y));
                    break;
                case PartType.NOSE:
                    SingletonData.CurrentFace = SingletonData.CurrentFace.updateNose(new FacePart(PartType.NOSE, partID, -differenceX * scale.x, -differenceY * scale.y));
                    break;
            }  
    }
    }


    private Vector2 getDisplacementScale()

    {

        Sprite sprite = Resources.Load("face0", typeof(Sprite)) as Sprite;

        float height = sprite.bounds.size.y;
        float width = sprite.bounds.size.x;
        return new Vector2(width, height);

    }


    void OnMouseDown()
    {

        if (obj != null)
        {
            Destroy(obj);
            obj = null;
        }
        Sprite sprite = Resources.Load(geFileName(), typeof(Sprite)) as Sprite;
        obj = new GameObject();
        Vector3 mousePos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        obj.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
        obj.transform.localScale = new Vector3(1f, 1f, 1);
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        rend.sortingOrder = 2;
        obj.transform.parent = gameObject.transform;
    }


    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        obj.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
    }



}
