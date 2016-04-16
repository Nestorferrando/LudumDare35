using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Face
{
    private FacePart leftEye;
    private FacePart rightEye;
    private FacePart nose;
    private FacePart mouth;
    private FacePart contour;
    private FacePart hair;

    private HairColor hairColor;
    private SkinColor skinColor;

    public Face(FacePart leftEye, FacePart rightEye, FacePart nose, FacePart mouth, FacePart contour, FacePart hair, HairColor hairColor, SkinColor skinColor)
    {
        this.leftEye = leftEye;
        this.rightEye = rightEye;
        this.nose = nose;
        this.mouth = mouth;
        this.contour = contour;
        this.hair = hair;
        this.hairColor = hairColor;
        this.skinColor = skinColor;
    }

    public FacePart LeftEye
    {
        get { return leftEye; }
    }

    public FacePart RightEye
    {
        get { return rightEye; }
    }

    public FacePart Nose
    {
        get { return nose; }
    }

    public FacePart Mouth
    {
        get { return mouth; }
    }

    public FacePart Contour
    {
        get { return contour; }
    }

    public FacePart Hair
    {
        get { return hair; }
    }

    public HairColor HairColor
    {
        get { return hairColor; }
    }

    public SkinColor SkinColor
    {
        get { return skinColor; }
    }


    public Face updateNose(FacePart nose)
    {
        return new Face(leftEye,rightEye,nose,mouth,contour,hair,hairColor,skinColor);
    }

    public Face updateMouth(FacePart mouth)
    {
        return new Face(leftEye, rightEye, nose, mouth, contour, hair, hairColor, skinColor);
    }

    public Face updateHair(FacePart hair)
    {
        return new Face(leftEye, rightEye, nose, mouth, contour, hair, hairColor, skinColor);
    }

    public Face updateLeftEye(FacePart leftEye)
    {
        return new Face(leftEye, rightEye, nose, mouth, contour, hair, hairColor, skinColor);
    }

    public Face updateRightEye(FacePart rightEye)
    {
        return new Face(leftEye, rightEye, nose, mouth, contour, hair, hairColor, skinColor);
    }

    public Face updateHairColor(HairColor hairColor)
    {
        return new Face(leftEye, rightEye, nose, mouth, contour, hair, hairColor, skinColor);
    }

    public Face updateSkinColor(SkinColor skinColor)
    {
        return new Face(leftEye, rightEye, nose, mouth, contour, hair, hairColor, skinColor);
    }

}

