using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public class FacePartLocation
    {
        private int id;
        private Vector3 screenLocation;

        public FacePartLocation( int id, Vector3 screenLocation)
        {
            this.id = id;
            this.screenLocation = screenLocation;
        }

        public int Id
        {
            get { return id; }
        }


        public Vector3 ScreenLocation
        {
            get { return screenLocation; }
        }
    }

