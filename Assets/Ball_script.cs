using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arm;
    private Vector3 startPosition_Ball;
    private Quaternion startRotation_Arm;
    void Start()
    {
        startPosition_Ball = transform.localPosition;
        startRotation_Arm = arm.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPosition_Ball;
            arm.transform.rotation = startRotation_Arm;
        }
    }
}
