using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class ColorUtils
    {

    public static UnityEngine.Color getHairColor(HairColor color)

    {
        switch (color)
        {
            case (HairColor.BLACK):   return UnityEngine.Color.black;
            case (HairColor.BROWN):
                return new UnityEngine.Color(165,84,21,1);
            case (HairColor.BLONDE):
                return new UnityEngine.Color(255, 229, 127, 1);
            case (HairColor.GINGER):
                return new UnityEngine.Color(217, 0, 0, 1);
            case (HairColor.LIGHT_BROWN):
                return new UnityEngine.Color(207, 144, 82, 1);
            case (HairColor.PALE_BLONDE):
                return new UnityEngine.Color(255, 255, 163, 1);
        }
         return UnityEngine.Color.white;
    }

    public static UnityEngine.Color getSkinColor(SkinColor color)

    {
        switch (color)
        {
            case (SkinColor.BLACK): return UnityEngine.Color.black;
            case (SkinColor.BROWN):
                return new UnityEngine.Color(165, 84, 21, 1);
            case (SkinColor.LIGHT_BROWN):
                return new UnityEngine.Color(255, 229, 127, 1);
            case (SkinColor.WHITE):
                return new UnityEngine.Color(217, 0, 0, 1);
            case (SkinColor.WHITE_PALE):
                return new UnityEngine.Color(207, 144, 82, 1);
            case (SkinColor.YELLOWISH):
                return new UnityEngine.Color(255, 255, 163, 1);
        }
        return UnityEngine.Color.white;
    }


}

