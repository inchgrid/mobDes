using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCaptureScript : MonoBehaviour
{
    public static InputCaptureScript instance;

    public BeamClass beam;
    public InputField beamInput;
    public InputField beam1;
    public InputField beam2;
    public InputField weightsInput;
    public InputField bag1;
    public InputField bag2;
    public Slider ratio1;
    public Text ratio1handleLabel;
    public InputField ratio2;
    public Text beamIndex;


    void Awake()
    {
        instance = this;
        beamInput.onEndEdit.AddListener(val => CalcFromBeam(val, 3));
        beam1.onEndEdit.AddListener(val => CalcFromBeam(val, 1));
        beam2.onEndEdit.AddListener(val => CalcFromBeam(val, 2));
        weightsInput.onEndEdit.AddListener(val => CalcFromWeight(val, 3));
        bag1.onEndEdit.AddListener(val => CalcFromWeight(val, 1));
        bag2.onEndEdit.AddListener(val => CalcFromWeight(val, 2));
        ratio1.onValueChanged.AddListener(val => CalcFromRatio(val));
        ratio2.onEndEdit.AddListener(val => CalcFromRatio2(val));
    }
    void Start()
    {
        beamInput.text = beam.LengthOfBeam.ToString();
        weightsInput.text = beam.BeamWeight.ToString();
        RatioLabelUpdate();
        beamIndex.text = beamIndex.text + beam.index;
    }

    public void CalcFromBeam(string lnth, int section)
    {
        float input = float.Parse(lnth);

        switch (section)
        {
            case 1:
                beam.DownPivot1.DownPivotLength = input;
                beam.DownPivot2.DownPivotLength = beam.LengthOfBeam - input;
                break;
            case 2:
                beam.DownPivot2.DownPivotLength = input;
                beam.DownPivot1.DownPivotLength = beam.LengthOfBeam - input;
                break;
            case 3:
                beam.LengthOfBeam = input;
                break;
            default:
                break;
        }

        RatioLabelUpdate();
    }

    void BeamLabelUpdate()
    {
        beam1.text = beam.DownPivot1.DownPivotLength.ToString();
        beam2.text = beam.DownPivot2.DownPivotLength.ToString();
    }

    public void CalcFromWeight(string wgt, int bag)
    {
        float input = float.Parse(wgt);

        switch (bag)
        {
            case 1:
                beam.DownPivot1.DownPivotWeight = input;
                beam.DownPivot2.DownPivotWeight = beam.BeamWeight - input;
                break;
            case 2:
                beam.DownPivot2.DownPivotWeight = input;
                beam.DownPivot1.DownPivotWeight = beam.BeamWeight - input;
                break;
            case 3:
                beam.BeamWeight = input;
                break;
            default:
                break;
        }

        RatioLabelUpdate();
    }

    void WeightLabelUpdate()
    {
        bag1.text = beam.DownPivot1.DownPivotWeight.ToString();
        bag2.text = beam.DownPivot2.DownPivotWeight.ToString();
    }

    public void CalcFromRatio(float rat)
    {
        beam.UpPivotRatio = rat;
        beam.DownPivot1.DownPivotRatio = rat;
        beam.DownPivot2.DownPivotRatio = 1 - rat;
        RatioLabelUpdate();
    }

    void RatioLabelUpdate()
    {

        ratio2.text = beam.DownPivot2.DownPivotRatio.ToString();
        ratio1.value = beam.DownPivot1.DownPivotRatio;
        ratio1handleLabel.text = beam.DownPivot1.DownPivotRatio.ToString();
        BeamLabelUpdate();
        WeightLabelUpdate();
    }

    public void CalcFromRatio2(string rat)
    {
        float input = float.Parse(rat);

        beam.DownPivot2.DownPivotRatio = input;
        beam.DownPivot1.DownPivotRatio = 1 - input;
        RatioLabelUpdate();
    }


}
