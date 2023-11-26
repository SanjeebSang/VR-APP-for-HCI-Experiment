using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

public class DataSyncManager
{
    private static DataSyncManager _instance;

    public static DataSyncManager GetInstance() {
        if (_instance == null) {
            _instance = new DataSyncManager();
            _instance.SetupSocket();
        }

        return _instance;
    }

    private Socket _socket; 

    public void SendMessage(SocketMessageTopic topic, string message) {
        SendMessageThroughSocket($"{topic}: message");
    }

    private void SetupSocket() {

    }

    private void SendMessageThroughSocket(string message) {

    }

    private void ShutdownSocket() {

    }
}
