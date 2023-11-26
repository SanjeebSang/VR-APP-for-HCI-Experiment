using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExperimentController
{
    private static ExperimentController _instance;

    public static ExperimentController GetInstance() {
        if (_instance == null) {
            _instance = new ExperimentController();
        }

        return _instance;
    }

    private int _currentExperimentNumber = 0;
    private List<ExperimentInfo> _experiments = new List<ExperimentInfo>() 
    {
        new ExperimentInfo(1, 1),
        new ExperimentInfo(2, 2),
        new ExperimentInfo(3, 3),
        new ExperimentInfo(4, 4),
        new ExperimentInfo(5, 5),
        new ExperimentInfo(6, 6),
        new ExperimentInfo(7, 7),
        new ExperimentInfo(8, 8),
        new ExperimentInfo(9, 9),
        new ExperimentInfo(10, 10),
        new ExperimentInfo(11, 11),
    };

    public ExperimentInfo GetCurrentExperimentInfo() {
        ExperimentInfo nextInfo = _experiments[_currentExperimentNumber];
        return nextInfo;
    }

    public void MoveToNextExperiment() {
         _currentExperimentNumber += 1;
    }

    public void NotifyMovementWillStart(DateTime startTime, string movementId) {

        DataSyncManager.GetInstance().SendMessage(SocketMessageTopic.MovementWillStart, $"Movement ID: {movementId}, StartTime: {startTime}");
    }

    public void NotifyMovementHasEnded(string movementId) {
        DataSyncManager.GetInstance().SendMessage(SocketMessageTopic.MovementHasEnded, $"Movement ID: {movementId}");
    }

    public void NotifyExperimentHasEnded() {
        DataSyncManager.GetInstance().SendMessage(SocketMessageTopic.ExperimentHasEnded, "All Movements are finished.");
    }
}
