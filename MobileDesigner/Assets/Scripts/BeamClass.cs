using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Initially will only allow 2 downPivots?
[Serializable]
public class BeamClass
{
    public int index;
    private float lengthOfBeam;
   // private float upPivotLocationOnBeam = 150f;
    private float upPivotRatio;
    private float upStringlength;
    private float beamWeight;
    [NonSerialized]
    private DownPivot downPivot1;
    [NonSerialized]
    private DownPivot downPivot2;
    private bool isBag = false;
    [NonSerialized]
    private BeamClass parentBeam = null;

    public BeamClass(float length, float weight, float ratio)
    {
        lengthOfBeam = length;
        beamWeight = weight;
        upPivotRatio = ratio;
        downPivot1 = new DownPivot(this);
        downPivot2 = new DownPivot(this);
        downPivot1.OtherDownPivot = downPivot2;
        downPivot2.OtherDownPivot = downPivot1;
    }
    public float LengthOfBeam
    {
        get { return lengthOfBeam; }
        set
        {
            lengthOfBeam = value;
            downPivot1.DownPivotLength = lengthOfBeam * downPivot1.DownPivotRatio;
            downPivot2.DownPivotLength = lengthOfBeam - downPivot1.DownPivotLength;
        }
    }
    //public float UpPivotLocOnbeam
    //{
    //    get { return upPivotLocationOnBeam; }
    //    set
    //    {
    //        upPivotLocationOnBeam = value;
    //        downPivot1.DownPivotRatio = upPivotLocationOnBeam / lengthOfBeam;
    //        downPivot1.DownPivotLength = upPivotLocationOnBeam;
    //        downPivot2.DownPivotLength = lengthOfBeam - downPivot1.DownPivotLength;
    //        downPivot2.DownPivotRatio = 1 - downPivot1.DownPivotRatio;
    //    }
    //}
    public float UpPivotRatio
    {
        get { return upPivotRatio; }
        set
        {
            upPivotRatio = value;
            downPivot1.DownPivotRatio = upPivotRatio;
            downPivot2.DownPivotRatio = 1 - downPivot1.DownPivotRatio;
            downPivot1.DownPivotLength = lengthOfBeam * downPivot1.DownPivotRatio;
            downPivot2.DownPivotLength = lengthOfBeam - downPivot1.DownPivotLength;
        }
    }
    public float UpStringLength
    {
        get { return upStringlength; }
        set
        {
            upStringlength = value;
        }
    }
    public float BeamWeight
    {
        get { return beamWeight; }
        set
        {
            beamWeight = value;
            downPivot1.DownPivotWeight = beamWeight * downPivot1.DownPivotRatio;
            downPivot2.DownPivotWeight = beamWeight - downPivot1.DownPivotWeight;
        }
    }
    public DownPivot DownPivot1
    {
        get { return downPivot1; }
        set
        {
            downPivot1 = value;
            downPivot2.OtherDownPivot = downPivot1;
            downPivot1.ThisBeam = this;
        }
    }
    public DownPivot DownPivot2
    {
        get { return downPivot2; }
        set
        {
            downPivot2 = value;
            downPivot1.OtherDownPivot = downPivot2;
            downPivot2.ThisBeam = this;
        }
    }
    public bool IsBag
    {
        get { return isBag; }
        set
        {
            isBag = value;
        }
    }
    public BeamClass ParentBeam
    {
        get { return parentBeam; }
        set
        {
            parentBeam = value;
            if (parentBeam != null) IsBag = true;
        }
    }

}
[System.Serializable]
public class DownPivot
{
    private float downPivotLength;
    private float downPivotRatio;
    private float downStringLength;
    private float downPivotWeight;
    [NonSerialized]
    private BeamClass thisBeam;
    [NonSerialized]
    private DownPivot otherDownPivot;
    private bool isParent;
    [NonSerialized]
    private BeamClass childBeam;

    public DownPivot(BeamClass ownerBeam)
    {
        thisBeam = ownerBeam;
    }

    public float DownPivotLength
    {
        get { return downPivotLength; }
        set
        {
            downPivotLength = value;
            downPivotRatio = downPivotLength / thisBeam.LengthOfBeam;
            //   otherDownPivot.DownPivotLength = thisBeam.LengthOfBeam - downPivotLength;
            //   otherDownPivot.DownPivotRatio = 1 - downPivotRatio;
        }
    }

    public float DownPivotRatio
    {
        get { return this.downPivotRatio; }
        set
        {
            downPivotRatio = value;
            downPivotLength = thisBeam.LengthOfBeam * downPivotRatio;
           // this.otherDownPivot.DownPivotLength = this.thisBeam.LengthOfBeam - this.downPivotLength;
           // this.otherDownPivot.DownPivotRatio = 1 - this.downPivotRatio;
            downPivotWeight = thisBeam.BeamWeight * downPivotRatio;
           // this.otherDownPivot.DownPivotWeight = this.thisBeam.BeamWeight - this.downPivotWeight;
        }
    }
    public float DownStringLength
    {
        get { return downStringLength; }
        set
        {
            downStringLength = value;
        }
    }
    public float DownPivotWeight
    {
        get { return downPivotWeight; }
        set
        {
            downPivotWeight = value;
            downPivotRatio = downPivotWeight / thisBeam.BeamWeight;
        }
    }
    public DownPivot OtherDownPivot
    {
        get { return otherDownPivot; }
        set
        {
            otherDownPivot = value;
            //otherDownPivot.ThisBeam = thisBeam;
        }
    }
    public BeamClass ThisBeam
    {
        get { return thisBeam; }
        set { thisBeam = value; }
    }
    public bool IsParent
    {
        get { return isParent; }
        set
        {
            isParent = value;
        }
    }
    public BeamClass ChildBeam
    {
        get { return childBeam; }
        set
        {
            childBeam = value;
        }
    }
}
