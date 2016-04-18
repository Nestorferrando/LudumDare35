using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public class Target
   {

       private TargetTrust _trust= TargetTrust.FIVE;

       public Target(TargetTrust trust)
       {
           this._trust = trust;
       }

       public TargetTrust Trust
       {
           get { return _trust; }
       }


       public Target decreaseConfidence()
       {

        TargetTrust trust = (TargetTrust) (((int) _trust) - 1);
        return new Target(trust);
       }

   }

