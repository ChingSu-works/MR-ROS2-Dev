using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using UnityEngine.UIElements;
using System;

/// <summary>
///
/// </summary>
public class ObjectControlRos : MonoBehaviour
{
    ROSConnection ros;
    public string rightHandTopicName = "right_hand_pos_rot";
    public string rightArmTopicName = "right_arm_pos_rot";
    public string rightShoulderTopicName = "right_shoulder_pos_rot";
    public string leftHandTopicName = "left_hand_pos_rot";
    public string leftArmTopicName = "left_arm_pos_rot";
    public string leftShoulderTopicName = "left_shoulder_pos_rot";

    // The game object
    public GameObject RightHandCube, LeftHandCube, RightArmCube, LeftArmCube, RightShoulderCube, LeftShoulderCube;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.01f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PosRotMsg>(rightHandTopicName);
        ros.RegisterPublisher<PosRotMsg>(rightArmTopicName);
        ros.RegisterPublisher<PosRotMsg>(rightShoulderTopicName);
        ros.RegisterPublisher<PosRotMsg>(leftHandTopicName);
        ros.RegisterPublisher<PosRotMsg>(leftArmTopicName);
        ros.RegisterPublisher<PosRotMsg>(leftShoulderTopicName);

    }

    private void Update()
    {
        //Debug.Log(cube.name);
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            //cube.transform.rotation = Random.rotation;

            PosRotMsg RightHandCubePos = new PosRotMsg(
                RightHandCube.transform.position.x,
                RightHandCube.transform.position.y,
                RightHandCube.transform.position.z,
                RightHandCube.transform.rotation.x,
                RightHandCube.transform.rotation.y,
                RightHandCube.transform.rotation.z,
                RightHandCube.transform.rotation.w
            );
            PosRotMsg RightArmCubePos = new PosRotMsg(
                RightArmCube.transform.position.x,
                RightArmCube.transform.position.y,
                RightArmCube.transform.position.z,
                RightArmCube.transform.rotation.x,
                RightArmCube.transform.rotation.y,
                RightArmCube.transform.rotation.z,
                RightArmCube.transform.rotation.w
            );
            PosRotMsg RightShoulderCubePos = new PosRotMsg(
                RightShoulderCube.transform.position.x,
                RightShoulderCube.transform.position.y,
                RightShoulderCube.transform.position.z,
                RightShoulderCube.transform.rotation.x,
                RightShoulderCube.transform.rotation.y,
                RightShoulderCube.transform.rotation.z,
                RightShoulderCube.transform.rotation.w
            );
            PosRotMsg LeftHandCubePos = new PosRotMsg(
                LeftHandCube.transform.position.x,
                LeftHandCube.transform.position.y,
                LeftHandCube.transform.position.z,
                LeftHandCube.transform.rotation.x,
                LeftHandCube.transform.rotation.y,
                LeftHandCube.transform.rotation.z,
                LeftHandCube.transform.rotation.w
            );
            PosRotMsg LeftArmCubePos = new PosRotMsg(
                LeftArmCube.transform.position.x,
                LeftArmCube.transform.position.y,
                LeftArmCube.transform.position.z,
                LeftArmCube.transform.rotation.x,
                LeftArmCube.transform.rotation.y,
                LeftArmCube.transform.rotation.z,
                LeftArmCube.transform.rotation.w
            );
            PosRotMsg LeftShoulderCubePos = new PosRotMsg(
                LeftShoulderCube.transform.position.x,
                LeftShoulderCube.transform.position.y,
                LeftShoulderCube.transform.position.z,
                LeftShoulderCube.transform.rotation.x,
                LeftShoulderCube.transform.rotation.y,
                LeftShoulderCube.transform.rotation.z,
                LeftShoulderCube.transform.rotation.w
            );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Publish(rightHandTopicName, RightHandCubePos);
            ros.Publish(rightArmTopicName, RightArmCubePos);
            ros.Publish(rightShoulderTopicName, RightShoulderCubePos);
            ros.Publish(leftHandTopicName, LeftHandCubePos);
            ros.Publish(leftArmTopicName, LeftArmCubePos);
            ros.Publish(leftShoulderTopicName, LeftShoulderCubePos);
             
            timeElapsed = 0;
        }
    }
}