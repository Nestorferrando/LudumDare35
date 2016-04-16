using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class FacesDatabase
    {

    public static Face SampleFace = new Face(
            new FacePart(PartType.LEFT_EYE, 0, -15.0f*0.55f, 15 * 0.55f),
            new FacePart(PartType.RIGHT_EYE, 0, 15 * 0.55f, 13 * 0.55f),
            new FacePart(PartType.NOSE, 0, 0, -3 * 0.55f),
            new FacePart(PartType.MOUTH, 0, 0, -30 * 0.55f),
            new FacePart(PartType.CONTOUR, 0, 0, 0),
            new FacePart(PartType.HAIR, 0, 0, 0),
            HairColor.GINGER,
            SkinColor.WHITE
            );

}

