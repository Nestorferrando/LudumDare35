using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum PartType { CONTOUR,NOSE,MOUTH,HAIR,LEFT_EYE,RIGHT_EYE,SKIN };

public class FacePart
{

    private PartType type;
    private int ID;
    private float offsetX;
    private float offsetY;


    public FacePart(PartType type, int id, float offsetX, float offsetY)
    {
        this.type = type;
        ID = id;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }

    private sealed class FacePartEqualityComparer : IEqualityComparer<FacePart>
    {
        public bool Equals(FacePart x, FacePart y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.type == y.type && x.ID == y.ID && x.offsetX.Equals(y.offsetX) && x.offsetY.Equals(y.offsetY);
        }

        public int GetHashCode(FacePart obj)
        {
            unchecked
            {
                var hashCode = (int) obj.type;
                hashCode = (hashCode*397) ^ obj.ID;
                hashCode = (hashCode*397) ^ obj.offsetX.GetHashCode();
                hashCode = (hashCode*397) ^ obj.offsetY.GetHashCode();
                return hashCode;
            }
        }
    }

    private static readonly IEqualityComparer<FacePart> FacePartComparerInstance = new FacePartEqualityComparer();

    public static IEqualityComparer<FacePart> FacePartComparer
    {
        get { return FacePartComparerInstance; }
    }

    public float OffsetX
    {
        get { return offsetX; }
    }

    public float OffsetY
    {
        get { return offsetY; }
    }

    public PartType Type
    {
        get { return type; }
    }

    public int Id
    {
        get { return ID; }
    }
}


