using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



  public class CorrespondenceUtils
  {
      private static float ERROR_PER_PIXEL = 1/32.0f;


      public static CorrespondenceError GetFaceError(Face idealFace, Face realFace)
      {
          return new CorrespondenceError(
              getFaceDisplacementError(idealFace,realFace)+ getFaceShapeError(idealFace, realFace), 
              getFaceDisplacementError(idealFace, realFace), 
              getMostDisplacedPart(idealFace, realFace),
              getFaceShapeError(idealFace, realFace),
              getPartWithWorstShape(idealFace, realFace));
      }

      private static PartType getMostDisplacedPart(Face idealFace, Face realFace)
      {
        PartType part = PartType.LEFT_EYE;
        float maxError = ERROR_PER_PIXEL *
      (float)Math.Sqrt(
          (idealFace.LeftEye.OffsetX - realFace.LeftEye.OffsetX) * (idealFace.LeftEye.OffsetX - realFace.LeftEye.OffsetX) +
          (idealFace.LeftEye.OffsetY - realFace.LeftEye.OffsetY) * (idealFace.LeftEye.OffsetY - realFace.LeftEye.OffsetY));


        float error= ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.RightEye.OffsetX - realFace.RightEye.OffsetX) * (idealFace.RightEye.OffsetX - realFace.RightEye.OffsetX) +
              (idealFace.RightEye.OffsetY - realFace.RightEye.OffsetY) * (idealFace.RightEye.OffsetY - realFace.RightEye.OffsetY));

          if (error > maxError)
          {
              error = maxError;
            part = PartType.RIGHT_EYE;
        }

        error = ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.Nose.OffsetX - realFace.Nose.OffsetX) * (idealFace.Nose.OffsetX - realFace.Nose.OffsetX) +
              (idealFace.Nose.OffsetY - realFace.Nose.OffsetY) * (idealFace.Nose.OffsetY - realFace.Nose.OffsetY));

        if (error > maxError)
        {
            error = maxError;
            part = PartType.NOSE;
        }


        error = ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.Mouth.OffsetX - realFace.Mouth.OffsetX) * (idealFace.Mouth.OffsetX - realFace.Mouth.OffsetX) +
              (idealFace.Mouth.OffsetY - realFace.Mouth.OffsetY) * (idealFace.Mouth.OffsetY - realFace.Mouth.OffsetY));

        if (error > maxError)
        {
            error = maxError;
            part = PartType.MOUTH;
        }

        return part;
      }

      private static float getFaceDisplacementError(Face idealFace, Face realFace)
    {
        float totalSimilarityError = 0;

        totalSimilarityError += ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.LeftEye.OffsetX - realFace.LeftEye.OffsetX) * (idealFace.LeftEye.OffsetX - realFace.LeftEye.OffsetX) +
              (idealFace.LeftEye.OffsetY - realFace.LeftEye.OffsetY) * (idealFace.LeftEye.OffsetY - realFace.LeftEye.OffsetY));

        totalSimilarityError += ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.RightEye.OffsetX - realFace.RightEye.OffsetX) * (idealFace.RightEye.OffsetX - realFace.RightEye.OffsetX) +
              (idealFace.RightEye.OffsetY - realFace.RightEye.OffsetY) * (idealFace.RightEye.OffsetY - realFace.RightEye.OffsetY));

        totalSimilarityError += ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.Nose.OffsetX - realFace.Nose.OffsetX) * (idealFace.Nose.OffsetX - realFace.Nose.OffsetX) +
              (idealFace.Nose.OffsetY - realFace.Nose.OffsetY) * (idealFace.Nose.OffsetY - realFace.Nose.OffsetY));

        totalSimilarityError += ERROR_PER_PIXEL *
          (float)Math.Sqrt(
              (idealFace.Mouth.OffsetX - realFace.Mouth.OffsetX) * (idealFace.Mouth.OffsetX - realFace.Mouth.OffsetX) +
              (idealFace.Mouth.OffsetY - realFace.Mouth.OffsetY) * (idealFace.Mouth.OffsetY - realFace.Mouth.OffsetY));

        return totalSimilarityError;
    }

      private static PartType getPartWithWorstShape(Face idealFace, Face realFace)
      {
        PartType part = PartType.CONTOUR;
        float maxError = getCorrespondenceError(idealFace.Contour, realFace.Contour);

        float error= getCorrespondenceError(idealFace.Hair, realFace.Hair);
          if (error > maxError)
          {
              maxError = error;
            part=PartType.HAIR;
          }

        error = getCorrespondenceError(idealFace.LeftEye, realFace.LeftEye);
        if (error > maxError)
        {
            maxError = error;
            part = PartType.LEFT_EYE;
        }

        error = getCorrespondenceError(idealFace.RightEye, realFace.RightEye);
        if (error > maxError)
        {
            maxError = error;
            part = PartType.RIGHT_EYE;
        }

        error = getCorrespondenceError(idealFace.Mouth, realFace.Mouth);
        if (error > maxError)
        {
            maxError = error;
            part = PartType.MOUTH;
        }

        error = getCorrespondenceError(idealFace.Nose, realFace.Nose);
        if (error > maxError)
        {
            maxError = error;
            part = PartType.NOSE;
        }

        error = getHairColorError(idealFace.HairColor, realFace.HairColor);
        if (error > maxError)
        {
            maxError = error;
            part = PartType.HAIR;
        }

        error = getSkinColorError(idealFace.SkinColor, realFace.SkinColor);
        if (error > maxError)
        {
            maxError = error;
            part = PartType.SKIN;
        }
          return part;
      }

      private static float getFaceShapeError(Face idealFace, Face realFace)
      {
          float totalSimilarityError = 0;

        totalSimilarityError += getCorrespondenceError(idealFace.Contour, realFace.Contour);
        totalSimilarityError += getCorrespondenceError(idealFace.Hair, realFace.Hair);
        totalSimilarityError += getCorrespondenceError(idealFace.LeftEye, realFace.LeftEye);
        totalSimilarityError += getCorrespondenceError(idealFace.RightEye, realFace.RightEye);
        totalSimilarityError += getCorrespondenceError(idealFace.Mouth, realFace.Mouth);
        totalSimilarityError += getCorrespondenceError(idealFace.Nose, realFace.Nose);
        totalSimilarityError += getHairColorError(idealFace.HairColor, realFace.HairColor);
        totalSimilarityError += getSkinColorError(idealFace.SkinColor, realFace.SkinColor);

        return totalSimilarityError;
      }



      private static float getCorrespondenceError(FacePart idealPart, FacePart chosenPart)

      {

          int idealIndex = idealPart.Id;
          int realIndex = chosenPart.Id;

          if (Math.Abs(idealIndex - realIndex) == 0) return 0;
           if (Math.Abs(idealIndex - realIndex) == 1) return 0.5f;
        if (Math.Abs(idealIndex - realIndex) > 1) return 1;

          return 1;
      }

    private static float getHairColorError(HairColor idealColor, HairColor chosenColor)

    {

        int idealIndex = (int) idealColor;
        int realIndex = (int) chosenColor;

        if (Math.Abs(idealIndex - realIndex) == 0) return 0;
        if (Math.Abs(idealIndex - realIndex) == 1) return 0.5f;
        if (Math.Abs(idealIndex - realIndex) > 1) return 1;
        return 1;
    }

    private static float getSkinColorError(SkinColor idealColor, SkinColor chosenColor)

    {

        int idealIndex = (int)idealColor;
        int realIndex = (int)chosenColor;

        if (Math.Abs(idealIndex - realIndex) == 0) return 0;
        if (Math.Abs(idealIndex - realIndex) == 1) return 0.5f;
        if (Math.Abs(idealIndex - realIndex) > 1) return 1;
        return 1;
    }
}

