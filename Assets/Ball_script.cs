using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arm;
    public GameObject wallLocation;
    public GameObject bodyCatapult;
    private Vector3 startPosition_Ball;
    private Quaternion startRotation_Arm;
    private Quaternion startRotation_Base;
    void Start()
    {
        startPosition_Ball = transform.localPosition;
        startRotation_Arm = arm.transform.localRotation;
        startRotation_Base = bodyCatapult.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPosition_Ball;
            arm.transform.rotation = startRotation_Arm;
            bodyCatapult.transform.rotation = startRotation_Base;
        }
    }
}
