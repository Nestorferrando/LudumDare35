using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.model.changeface
{


 public   class FacePartRemoval
 {
     private GameObject go;
     private GameObject newGO;
     private bool removeByAlpha;

     public FacePartRemoval(GameObject go, GameObject newGo, bool removeByAlpha)
     {
         this.go = go;
         newGO = newGo;
         this.removeByAlpha = removeByAlpha;
     }


     public GameObject Go
     {
         get { return go; }
     }

     public GameObject NewGo
     {
         get { return newGO; }
     }

     public bool RemoveByAlpha
     {
         get { return removeByAlpha; }
     }
 }
}
