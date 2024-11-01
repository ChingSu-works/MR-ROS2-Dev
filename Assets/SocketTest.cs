using System.Collections;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Transport;
using SocketIOClient.Newtonsoft.Json;
using UnityEngine;
using System;

public class SocketTest : MonoBehaviour
{
    public SocketIOUnity socket;
    void Start()
    {
        var uri = new Uri("http://10.100.3.116:5000");
        socket = new SocketIOUnity(uri, new SocketIOOptions
        {
            EIO = 4,
            Transport = TransportProtocol.Polling,
        });

        socket.JsonSerializer = new NewtonsoftJsonSerializer();

        socket.OnConnected += (sender, e) =>
        {
            Debug.Log("socket.OnConnected");
        };
        socket.OnDisconnected += (sender, e) =>
        {
            Debug.Log("disconnect: " + e);
        };
        socket.OnReconnectAttempt += (sender, e) =>
        {
            Debug.Log($"{DateTime.Now} Reconnecting: attempt = {e}");
        };


        Debug.Log("Connecting...");
        socket.Connect();
        Debug.Log("Setup finished");

    }
}
