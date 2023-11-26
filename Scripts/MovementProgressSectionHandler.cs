using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MovementProgressSectionHandler : MonoBehaviour
{
    public Image ProgressImage;
    public Text TextInfo;
    public GameObject ContinueButton;
    public GameObject MovementSection;
    private ExperimentInfo _experimentInfo;
    private int _progress;
    private DateTime _startTime;
    private bool _shouldUpdateGui = true;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGuiIfNeeded();
        _startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGuiIfNeeded();
    }

    private void UpdateGuiIfNeeded() 
    {
        GameObject go = GetComponent<GameObject>();
        if (go.activeInHierarchy) 
        {
            ExperimentInfo info = ExperimentController.GetInstance().GetCurrentExperimentInfo();
            if (_experimentInfo == null || _experimentInfo != info) 
            {
                _experimentInfo = info;
                _shouldUpdateGui = true;
            }

            DateTime c = DateTime.Now;
            if ((c - _startTime) > TimeSpan.FromMilliseconds(100)) {
                if (_progress < 100) 
                {
                    _progress += 5;
                    _shouldUpdateGui = true;
                }
            }

            if (_shouldUpdateGui) 
            {
                SetValuesInGUI(_experimentInfo);
                _shouldUpdateGui = false;
            }
        }
    }

    private void SetValuesInGUI(ExperimentInfo info) 
    {
        TextInfo.text = info.Text;
    }

    public void LoadNewValue() 
    {
        _experimentInfo = null;
    }
}
