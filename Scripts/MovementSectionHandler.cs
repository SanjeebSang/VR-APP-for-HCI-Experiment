using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSectionHandler : MonoBehaviour
{
    public Image MovementImage;
    public Text MovementInfo;
    public GameObject StartButton;
    public GameObject MovementProgressSection;
    private ExperimentInfo _currentExperimentInfo;
    private bool _shouldUpdateGui = true;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGuiIfNeeded();
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
            if (_currentExperimentInfo == null || _currentExperimentInfo != info) 
            {
                _shouldUpdateGui = true;
                _currentExperimentInfo = info;
            }

            if (_shouldUpdateGui) 
            {
                SetValues(_currentExperimentInfo);
                _shouldUpdateGui = false;
            }
        }
    }

    private void SetValues(ExperimentInfo info) 
    {
        MovementInfo.text = info.Text;
    }

    public void LoadNewData() {
        _currentExperimentInfo = null;
    }
}
