using System;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Transport;
using SocketIOClient.Newtonsoft.Json;
using UnityEngine;
using Oculus.Movement.BodyTrackingForFitness;

public class AvatarSocketIO : MonoBehaviour
{

    public SocketIOUnity socket;
    public BodyPoseController BodyPoseController;
    public Dictionary<string, int> motor_replay = new Dictionary<string, int>();

    public GameObject LeftUpperArm, LeftLowerArm, RightUpperArm, RightLowerArm;

    public List<Dictionary<string, int>> List_To_Store_Motor = new List<Dictionary<string, int>>();
    public List<Dictionary<string, int>> List_To_Replay_Motor = new List<Dictionary<string, int>>();
    public Dictionary<string, int> motorvalue = new Dictionary<string, int>();

    public int AvatarSkeletonValue = 1;
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

    private void Update()
    {
        Debug.Log("LeftShoulderRotation" +      LeftUpperArm.transform.localEulerAngles.x);
        Debug.Log("LeftArmRotation" +           LeftUpperArm.transform.localEulerAngles.z);
        Debug.Log("LeftHandRotation" +          LeftLowerArm.transform.localEulerAngles.z);
        Debug.Log("RightShoulderRotation" +     RightUpperArm.transform.localEulerAngles.x);
        Debug.Log("RightArmRotation" +          RightUpperArm.transform.localEulerAngles.z);
        Debug.Log("RightHandRotation" +         RightLowerArm.transform.localEulerAngles.z);

        socket.Emit("LeftShoulderRotation",     LeftUpperArm.transform.localEulerAngles.x);
        socket.Emit("LeftArmRotation",          LeftUpperArm.transform.localEulerAngles.z);
        socket.Emit("LeftHandRotation",         LeftLowerArm.transform.localEulerAngles.z);
        socket.Emit("RightShoulderRotation",    RightUpperArm.transform.localEulerAngles.x);
        socket.Emit("RightArmRotation",         RightUpperArm.transform.localEulerAngles.z);
        socket.Emit("RightHandRotation",        RightLowerArm.transform.localEulerAngles.z);
    }

    private void OnDestroy()
    {
        socket.Dispose();
    }

    private void OnApplicationQuit()
    {
    }
}