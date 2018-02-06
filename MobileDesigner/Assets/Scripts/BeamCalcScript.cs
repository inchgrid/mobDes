using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeamCalcScript : MonoBehaviour
{
   
    public static BeamClass beam1;




    //public void InitialiseBeam()
    //{
    //    beam1 = new BeamClass(BeamsManager.instance.defaultBeamLength, BeamsManager.instance.defaultBeamWeight);
    //    BeamsManager.instance.beamsList.Add(beam1);
    //    beam1.index = BeamsManager.instance.beamsList.Count - 1;
    //    //InputCaptureScript.instance.CalcFromRatio(beam1.UpPivotRatio);
    //}

}


//public class BeamCalcScript : MonoBehaviour
//{
//    public static BeamCalcScript instance;
//    [SerializeField]
//    public Beam beam;
//    [SerializeField]
//    public Weights weights;

//    public float beamLength = 1000;
//    public float weightsTotal = 1000;
//    public float ratio = 0.5f;

//	void Awake ()
//    {
//        instance = this;
//        beam = new Beam();
//        weights = new Weights();
//	}

//    public void InitialiseBeam()
//    {
//        beam.Length = beamLength;
//        weights.Weight = weightsTotal;
//        beam.Ratio1 = ratio;
//        weights.Ratio1 = ratio;
//        InputCaptureScript.instance.CalcFromBeam(beamLength.ToString(), 3);

//    }

//}
