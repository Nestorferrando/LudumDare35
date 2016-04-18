using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public class Target
   {

       private TargetTrust _trust= TargetTrust.FIVE;
       private PartType concernType;

       public Target(TargetTrust trust, PartType concernType)
       {
           _trust = trust;
           this.concernType = concernType;
       }

       public TargetTrust Trust
       {
           get { return _trust; }
       }

       public PartType ConcernType
       {
           get { return concernType; }
       }


       public Target decreaseConfidence()
       {

        TargetTrust trust = (TargetTrust) (((int) _trust) - 1);
        return new Target(trust, concernType);
       }

   }

