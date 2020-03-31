using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arm;
    private Vector3 startPosition_Ball;
    private Vector3 startPosition_Arm;
    void Start()
    {
        startPosition_Ball = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("pozycja ramienia: "
                + " X:" + arm.transform.localPosition.x
                + " Y:" + arm.transform.localPosition.y
                + " Z:" + arm.transform.localPosition.z);
            Debug.Log("startowa pozycja ramienia: "
                + " X:" + startPosition_Arm.x
                + " Y:" + startPosition_Arm.y
                + " Z:" + startPosition_Arm.z);
            transform.position = startPosition_Ball;

        }
    }
}
