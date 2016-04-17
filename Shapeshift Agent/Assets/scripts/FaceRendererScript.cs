using System;
using System.Collections.Generic;
using Assets.scripts.model.changeface;
using UnityEngine;

public class FaceRendererScript : MonoBehaviour
{
    private GameObject currentContour;
    private GameObject currentContourBack;
    private GameObject currentHair;
    private GameObject currentLeftEye;
    private GameObject currentMouth;
    private GameObject currentNose;
    private GameObject currentRightEye;


    private SingletonData data;
    private Face PreviousFace;
    public float scale = 0.5f;

    private List<FacePartRemoval> shitToBeRemoved;
    private List<FacePartRemoval> shitRecentlyAdded;

    private void Start()
    {
        shitToBeRemoved = new List<FacePartRemoval>();
        shitRecentlyAdded = new List<FacePartRemoval>();

        data = GameObject.Find("SingletonData").GetComponent<SingletonData>();

        Sprite sprite = Resources.Load("clothes", typeof(Sprite)) as Sprite;
        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.09f);
        obj.transform.localScale = new Vector3(scale, scale, 1);
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = sprite;
        obj.transform.parent = gameObject.transform;
 
    }


    // Update is called once per frame
    private void Update()
    {




        if (PreviousFace != data.CurrrentFace && shitToBeRemoved.Count==0 && shitRecentlyAdded.Count==0)
        {
            renderFace(PreviousFace, data.CurrrentFace);
            
            PreviousFace = data.CurrrentFace;
        }
        //------------------------------

        List<FacePartRemoval> readyToRemove = new List<FacePartRemoval>();

        foreach (FacePartRemoval child in shitToBeRemoved)
        {
            if (child.Go != null)
            {
                if (child.RemoveByAlpha)
                {
                    child.Go.GetComponent<SpriteRenderer>().material.color=new Color(child.Go.GetComponent<SpriteRenderer>().material.color.r, child.Go.GetComponent<SpriteRenderer>().material.color.g, child.Go.GetComponent<SpriteRenderer>().material.color.b, child.Go.GetComponent<SpriteRenderer>().material.color.a*0.8f);

                    if (child.Go.GetComponent<SpriteRenderer>().material.color.a < 0.01f) readyToRemove.Add(child);

                }
                else
                {
                    child.Go.GetComponent<SpriteRenderer>().transform.localScale =
                        new Vector3(child.Go.GetComponent<SpriteRenderer>().transform.localScale.x * 0.8f,
                            child.Go.GetComponent<SpriteRenderer>().transform.localScale.y * 0.8f, 1);
                    if (child.Go.GetComponent<SpriteRenderer>().transform.localScale.x < 0.01f) readyToRemove.Add(child);

                }
            }
        }

        foreach (FacePartRemoval child in readyToRemove)
        {
            shitToBeRemoved.Remove(child);
            Destroy(child.Go);
            child.NewGo.transform.Translate(0, 0, -20);
            shitRecentlyAdded.Add(child);
        }
        readyToRemove.Clear();

        foreach (FacePartRemoval child in shitRecentlyAdded)
        {
                if (child.RemoveByAlpha)
                {
                    child.NewGo.GetComponent<SpriteRenderer>().color = new Color(
                        child.NewGo.GetComponent<SpriteRenderer>().color.r, 
                        child.NewGo.GetComponent<SpriteRenderer>().color.g, 
                        child.NewGo.GetComponent<SpriteRenderer>().color.b, 
                        child.NewGo.GetComponent<SpriteRenderer>().color.a +0.03f);
                    if (child.NewGo.GetComponent<SpriteRenderer>().color.a >=1) readyToRemove.Add(child);
                }

                else
                {
                    child.NewGo.GetComponent<SpriteRenderer>().transform.localScale =
                        new Vector3(child.NewGo.GetComponent<SpriteRenderer>().transform.localScale.x +0.08f,
                            child.NewGo.GetComponent<SpriteRenderer>().transform.localScale.y + 0.08f, 1);
                    if (child.NewGo.GetComponent<SpriteRenderer>().transform.localScale.x >= scale)
                    {
                    child.NewGo.GetComponent<SpriteRenderer>().transform.localScale =
                     new Vector3(scale, scale, 1);
                    readyToRemove.Add(child);
                    }

                }
        }


        foreach (FacePartRemoval child in readyToRemove)
        {
            shitRecentlyAdded.Remove(child);
        }
        //------------------------------




    }

    private void renderFace(Face previousFace, Face face)

    {
  



        var sprite = Resources.Load("face" + face.Contour.Id, typeof (Sprite)) as Sprite;
        var height = sprite.bounds.size.y;
        var width = sprite.bounds.size.x;

        GameObject obj;
        SpriteRenderer rend;

        if (previousFace==null || !face.Contour.Equals(previousFace.Contour) || face.SkinColor != previousFace.SkinColor)
        {
            obj = new GameObject();
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.25f);
            obj.transform.localScale = new Vector3(scale, scale, 1);
            if (previousFace != null) obj.transform.Translate(0,0,20);
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            rend.sprite = sprite;
            rend.color = ColorUtils.getSkinColor(face.SkinColor);
            if (previousFace != null) rend.color = new Color(rend.color.r,rend.color.g,rend.color.b,0);
            obj.transform.parent = gameObject.transform;
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentContour,obj, true));
            currentContour = obj;

            sprite = Resources.Load("face" + face.Contour.Id + "_back", typeof (Sprite)) as Sprite;
            obj = new GameObject();
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
            obj.transform.localScale = new Vector3(scale, scale, 1);
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            rend.sprite = sprite;
            rend.color = ColorUtils.getSkinColor(face.SkinColor);
            obj.transform.parent = gameObject.transform;
            if (previousFace != null) rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0);
            if (previousFace != null) obj.transform.Translate(0, 0, 20);
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentContourBack, obj, true));
            currentContourBack = obj;
        }

        if (previousFace == null ||  !face.Hair.Equals(previousFace.Hair) || face.HairColor != previousFace.HairColor)
        {

            sprite = Resources.Load("hair" + face.Hair.Id, typeof (Sprite)) as Sprite;
            obj = new GameObject();
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            rend.sprite = sprite;
            rend.color = ColorUtils.getHairColor(face.HairColor);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
            obj.transform.localScale = new Vector3(scale, scale, 1);
            obj.transform.parent = gameObject.transform;

            if (previousFace != null) rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0);
            if (previousFace != null) obj.transform.Translate(0, 0, 20);
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentHair, obj, true));
            currentHair = obj;
        }

        if (previousFace == null ||  !face.LeftEye.Equals(previousFace.LeftEye) )
        {

            sprite = Resources.Load("left_eye" + face.LeftEye.Id, typeof (Sprite)) as Sprite;
            obj = new GameObject();
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            rend.sprite = sprite;
            obj.transform.position = new Vector3(transform.position.x + face.LeftEye.OffsetX*scale/width,
                transform.position.y + face.LeftEye.OffsetY*scale/height, -0.3f);
            if (previousFace != null) obj.transform.localScale = new Vector3(0, 0, 1);
            obj.transform.parent = gameObject.transform;
            if (previousFace != null) obj.transform.Translate(0, 0, 20);
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentLeftEye, obj, false));
            currentLeftEye = obj;

        }

        if (previousFace == null || !face.RightEye.Equals(previousFace.RightEye))
        {
            sprite = Resources.Load("right_eye" + face.RightEye.Id, typeof (Sprite)) as Sprite;
            obj = new GameObject();
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            rend.sprite = sprite;
            obj.transform.position = new Vector3(transform.position.x + face.RightEye.OffsetX*scale/width,
                transform.position.y + face.RightEye.OffsetY*scale/height, -0.3f);
            if (previousFace != null) obj.transform.localScale = new Vector3(0, 0, 1);
            obj.transform.parent = gameObject.transform;
            if (previousFace != null) obj.transform.Translate(0, 0, 20);
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentRightEye, obj, false));
            currentRightEye = obj;
        }

        if (previousFace == null || !face.Mouth.Equals(previousFace.Mouth))
        {

            sprite = Resources.Load("mouth" + face.Mouth.Id, typeof (Sprite)) as Sprite;
            obj = new GameObject();
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            obj.transform.position = new Vector3(transform.position.x + face.Mouth.OffsetX*scale/width,
                transform.position.y + face.Mouth.OffsetY*scale/height, -0.4f);
            if (previousFace != null) obj.transform.localScale = new Vector3(0, 0, 1);
            rend.sprite = sprite;
            obj.transform.parent = gameObject.transform;
            if (previousFace != null) obj.transform.Translate(0, 0, 20);
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentMouth, obj, false));
            currentMouth = obj;
        }
        if (previousFace == null || !face.Nose.Equals(previousFace.Nose))
        {
            sprite = Resources.Load("nose" + face.Nose.Id, typeof (Sprite)) as Sprite;
            obj = new GameObject();
            rend = obj.AddComponent(typeof (SpriteRenderer)) as SpriteRenderer;
            obj.transform.position = new Vector3(transform.position.x + face.Nose.OffsetX*scale/width,
                transform.position.y + face.Nose.OffsetY*scale/height, -0.4f);
            if (previousFace != null)   obj.transform.localScale = new Vector3(0, 0, 1);
            rend.sprite = sprite;
            obj.transform.parent = gameObject.transform;
            if (previousFace != null) obj.transform.Translate(0, 0, 20);
            if (previousFace != null) shitToBeRemoved.Add(new FacePartRemoval(currentNose, obj, false));
            currentNose = obj;
        }
    }
}