using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamsManager : MonoBehaviour
{
    public static BeamsManager instance;

    public List<BeamClass> beamsList;
    public GameObject beamPanelPrefab;
    public float defaultBeamLength;
    public float defaultBeamWeight;
    public float defaultRatio;

    void Awake()
    {
        instance = this;
        beamsList = new List<BeamClass>();
    }

    public void AddBeam()
    {
        GameObject newPanel = Instantiate(beamPanelPrefab) as GameObject;
        newPanel.transform.SetParent(transform);
       // BeamCalcScript thisBeamScr = newPanel.GetComponent<BeamCalcScript>();
        BeamClass newbeam = new BeamClass(defaultBeamLength, defaultBeamWeight, defaultRatio);
        newPanel.GetComponent<InputCaptureScript>().beam = newbeam;

        beamsList.Add(newbeam);
        newbeam.index = beamsList.Count - 1;
        newPanel.GetComponent<InputCaptureScript>().CalcFromRatio(defaultRatio);
        newPanel.SetActive(true);


    }

    public void AddBeamAbove(GameObject childPanel)
    {
        GameObject newPanel = Instantiate(beamPanelPrefab) as GameObject;
        newPanel.transform.SetParent(transform);
        // BeamCalcScript thisBeamScr = newPanel.GetComponent<BeamCalcScript>();
        BeamClass newbeam = new BeamClass(defaultBeamLength, defaultBeamWeight, defaultRatio);
        newPanel.GetComponent<InputCaptureScript>().beam = newbeam;

        beamsList.Add(newbeam);
        newbeam.index = beamsList.Count - 1;
        BeamClass child = childPanel.GetComponent<InputCaptureScript>().beam;
        child.ParentBeam = newbeam;
        newbeam.DownPivot1.IsParent = true;

        newbeam.DownPivot1.DownPivotWeight = child.BeamWeight;

        newPanel.GetComponent<InputCaptureScript>().CalcFromRatio(defaultRatio);
        newPanel.SetActive(true);


    }
}
