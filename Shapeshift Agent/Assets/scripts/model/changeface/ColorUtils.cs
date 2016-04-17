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
            case (HairColor.BLACK): return new UnityEngine.Color(32 / 255.0f, 32 / 255.0f, 32 / 255.0f, 1);
            case (HairColor.BROWN):
                return new UnityEngine.Color(100/255.0f,34 / 255.0f, 13 / 255.0f, 1);
            case (HairColor.BLONDE):
                return new UnityEngine.Color(255 / 255.0f, 229 / 255.0f, 127 / 255.0f, 1);
            case (HairColor.GINGER):
                return new UnityEngine.Color(235 / 255.0f, 86/255.0f, 41/255.0f, 1);
            case (HairColor.LIGHT_BROWN):
                return new UnityEngine.Color(207 / 255.0f, 144 / 255.0f, 82 / 255.0f, 1);
            case (HairColor.PALE_BLONDE):
                return new UnityEngine.Color(255 / 255.0f, 255 / 255.0f, 163 / 255.0f, 1);
        }
         return UnityEngine.Color.blue;
    }

    public static UnityEngine.Color getSkinColor(SkinColor color)

    {
        switch (color)
        {
            case (SkinColor.BLACK): return new UnityEngine.Color(137 / 255.0f, 64 / 255.0f, 14 / 255.0f, 1);
            case (SkinColor.BROWN):
                return new UnityEngine.Color(228 / 255.0f, 148 / 255.0f, 93 / 255.0f, 1);
            case (SkinColor.LIGHT_BROWN):
                return new UnityEngine.Color(240 / 255.0f, 180 / 255.0f, 138 / 255.0f, 1);
            case (SkinColor.WHITE_PALE):
                return new UnityEngine.Color(255 / 255.0f, 240/255.0f, 240/255.0f, 1);
            case (SkinColor.WHITE):
                return new UnityEngine.Color(255 / 255.0f, 220 / 255.0f, 181 / 255.0f, 1);
            case (SkinColor.YELLOWISH):
                return new UnityEngine.Color(255 / 255.0f, 240 / 255.0f, 202 / 255.0f, 1);
        }
        return UnityEngine.Color.white;
    }


}

