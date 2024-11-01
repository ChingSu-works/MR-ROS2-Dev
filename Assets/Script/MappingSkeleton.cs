using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MappingSkeleton : MonoBehaviour
{
    public GameObject HandLeftCube, ArmLeftCube, ShoulderLeftCube, ShoulderRightCube, ArmRightCube, HandRightCube;
    public GameObject LeftUpperArm, LeftLowerArm, RightShoulder, RightUpperArm, RightLowerArm;

    public Vector3 MappedShoulder_L, MappedShoulder_R, MappedArm_L, MappedArm_R, MappedHand_L, MappedHand_R;
    float MapShoulderL_Y, MapShoulderR_Y, MapArmL_X, MapArmR_X, MapHandL_X, MapHandR_X;

    // Update is called once per frame
    void Update()
    {
        if (LeftUpperArm.transform.rotation.y * 200f - 90 < 0)
        {
            MapShoulderL_Y = LeftUpperArm.transform.rotation.y * 200f - 90 + 360;
        }

        MappedShoulder_L = new Vector3(0, MapShoulderL_Y, 0);

        MappedArm_L = new Vector3(LeftUpperArm.transform.rotation.x * 200f - 70, 0, 0);
        MappedHand_L = new Vector3(LeftLowerArm.transform.rotation.x * 200f - 50, 0, 0);

        ShoulderLeftCube.transform.localEulerAngles = MappedShoulder_L;
        ArmLeftCube.transform.localEulerAngles = MappedArm_L;
        HandLeftCube.transform.localEulerAngles = MappedHand_L;


        // MappedShoulder_R = new Vector3(0, MapShoulderR_Y, 0);

        // MappedArm_R = new Vector3(RightUpperArm.transform.rotation.x * -200f + 70, 0, 0);
        // MappedHand_R = new Vector3(RightLowerArm.transform.rotation.x * -200f + 50, 0, 0);

        // ShoulderRightCube.transform.localEulerAngles = MappedShoulder_R;
        // ArmRightCube.transform.localEulerAngles = MappedArm_R;
        // HandRightCube.transform.localEulerAngles = MappedHand_R;


    }
}
