using System;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Transport;
using SocketIOClient.Newtonsoft.Json;
using UnityEngine;
using Oculus.Movement.BodyTrackingForFitness;

public class AvatarSocketIOV2 : MonoBehaviour
{
    public SocketIOUnity socket;
    public MappingSkeleton mappedSkeleton;
    public GameObject Shoulder_L_mapping, Shoulder_R_mapping, Arm_L_mapping, Arm_R_mapping, Hand_L_mapping, Hand_R_mapping; 

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
        // Debug.Log("LeftShoulderRotation" +      Shoulder_L_mapping.transform.localEulerAngles.y);
        // Debug.Log("LeftArmRotation" +           Arm_L_mapping.transform.localEulerAngles.x);
        // Debug.Log("LeftHandRotation" +          Hand_L_mapping.transform.localEulerAngles.x);
        // Debug.Log("RightShoulderRotation" +     RightUpperArm.transform.localEulerAngles.x);
        // Debug.Log("RightArmRotation" +          RightUpperArm.transform.localEulerAngles.z);
        // Debug.Log("RightHandRotation" +         RightLowerArm.transform.localEulerAngles.z);

        socket.Emit("LeftShoulderRotation",     mappedSkeleton.MappedShoulder_L.y);
        // socket.Emit("LeftArmRotation",          mappedSkeleton.MappedShoulder_L.x);
        // socket.Emit("LeftHandRotation",         mappedSkeleton.MappedShoulder_L.x);
        // socket.Emit("RightShoulderRotation",    RightUpperArm.transform.localEulerAngles.x);
        // socket.Emit("RightArmRotation",         RightUpperArm.transform.localEulerAngles.z);
        // socket.Emit("RightHandRotation",        RightLowerArm.transform.localEulerAngles.z);
    }

    private void OnDestroy()
    {
        socket.Dispose();
    }

    private void OnApplicationQuit()
    {
    }
}
