using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public class Target
   {

       private TargetConfidence _confidence= TargetConfidence.FIVE;

       public Target(TargetConfidence confidence)
       {
           this._confidence = confidence;
       }

       public TargetConfidence Confidence
       {
           get { return _confidence; }
       }


       public Target decreaseConfidence()
       {

        TargetConfidence confidence = (TargetConfidence) (((int) _confidence) - 1);
        return new Target(confidence);
       }

   }

