using UnityEngine;

public class HeadController : MonoBehaviour
{
    public ArticulationBody headJoint; // Assign the ArticulationBody for the head joint in the Inspector
    public float rotationSpeed = 50f;  // Speed of rotation in degrees per second

    void Update()
    {
        if (headJoint != null)
        {
            // Get user input for rotation
            float rotationInput = Input.GetAxis("Horizontal"); // Use Left/Right arrow keys or A/D keys

            // Update the target position for the joint
            var drive = headJoint.xDrive;
            drive.target += rotationInput * rotationSpeed * Time.deltaTime; // Increment target position
            headJoint.xDrive = drive;
        }
    }
}
