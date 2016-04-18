using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class FacesDatabase
    {


    public static Face Subject1 = new Face(
        new FacePart(PartType.LEFT_EYE, 2, -7.77f, 7.77f),
        new FacePart(PartType.RIGHT_EYE, 2, 6.75f, 8.30f),
        new FacePart(PartType.NOSE, 1, 0.386f, -2.74f),
        new FacePart(PartType.MOUTH, 1, 1.38f, -15.54f),
        new FacePart(PartType.CONTOUR, 0, 0, 0),
        new FacePart(PartType.HAIR, 3, 0, 0),
        HairColor.BLONDE,
        SkinColor.WHITE
        );

    public static Face Subject2 = new Face(
            new FacePart(PartType.LEFT_EYE, 5, -8.6f, 5.46f),
            new FacePart(PartType.RIGHT_EYE, 5, 8.53f,7.02f),
            new FacePart(PartType.NOSE, 0, 0.08f, -5.05f),
            new FacePart(PartType.MOUTH, 0, 0.39f, -14.2f),
            new FacePart(PartType.CONTOUR, 1, 0, 0),
            new FacePart(PartType.HAIR, 0, 0, 0),
            HairColor.BROWN,
            SkinColor.BLACK
            );

    public static Face Subject3 = new Face(
            new FacePart(PartType.LEFT_EYE, 1, -8.17f, 3.16f),
            new FacePart(PartType.RIGHT_EYE, 0, 9.144f, 5.22f),
            new FacePart(PartType.NOSE, 5, 1.78f, -0.94f),
            new FacePart(PartType.MOUTH, 2, 1.58f, -15.54f),
            new FacePart(PartType.CONTOUR, 2, 0, 0),
            new FacePart(PartType.HAIR, 2, 0, 0),
            HairColor.BLACK,
            SkinColor.WHITE_PALE
            );

    public static Face Subject4 = new Face(
        new FacePart(PartType.LEFT_EYE, 5, -4.98f, 7.02f),
        new FacePart(PartType.RIGHT_EYE, 5, 5.95f, 8.82f),
        new FacePart(PartType.NOSE, 3, 1.382f, -3.51f),
        new FacePart(PartType.MOUTH, 3, 1.18f, -13.07f),
        new FacePart(PartType.CONTOUR, 3, 0, 0),
        new FacePart(PartType.HAIR, 1, 0, 0),
        HairColor.BLACK,
        SkinColor.BROWN
        );


    public static Face Subject5 = new Face(
        new FacePart(PartType.LEFT_EYE, 5, -6.57f, 7.79f),
        new FacePart(PartType.RIGHT_EYE, 5, 8.54f, 3.16f),
        new FacePart(PartType.NOSE, 4, 1.382f, -3.51f),
        new FacePart(PartType.MOUTH, 4, 0.78f, -18.4f),
        new FacePart(PartType.CONTOUR, 5, 0, 0),
        new FacePart(PartType.HAIR, 4, 0, 0),
        HairColor.GINGER,
        SkinColor.WHITE
        );


    public static Face Protagonist = new Face(
        new FacePart(PartType.LEFT_EYE, 2, -7.08f, 4.65f),
        new FacePart(PartType.RIGHT_EYE, 2, 7.39f,5f),
        new FacePart(PartType.NOSE, 4, 1.382f, -2.12f),
        new FacePart(PartType.MOUTH, 2, 0.70f, -14.56f),
        new FacePart(PartType.CONTOUR, 1, 0, 0),
        new FacePart(PartType.HAIR, 5, 0, 0),
        HairColor.GINGER,
        SkinColor.LIGHT_BROWN
        );

        public static Face InitialFace = Subject1;

        public static Face getFaceFromLevel(int currentInfiltrationLevel)
        {
            switch (currentInfiltrationLevel)
            {
            case 0: return Subject1;
            case 1: return Subject2;
            case 2: return Subject3;
            case 3: return Subject4;
            case 4: return Subject5;
        }
            return null;
        }
    }

