using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arm;
    public GameObject wallLocation;
    public GameObject bodyCatapult;
    public GameObject textInfo;
    public GameObject leftBrakeCatapult;
    public GameObject rightBrakeCatapult;
    public GameObject mainPartOfCatapult;

    private Vector3 startPosition_Ball;
    private Quaternion startRotation_Arm;
    private Quaternion startRotation_Base;
    private Quaternion startRotation_LeftBrake;
    private Quaternion startRotation_RightBrake;
    private Quaternion mainPartRotation;
    private float mainPartAngle;
    private float mainPartAngleRadius;

    void Start()
    {
        startPosition_Ball = transform.localPosition;
        startRotation_Arm = arm.transform.localRotation;
        startRotation_Base = bodyCatapult.transform.rotation;
        startRotation_LeftBrake = leftBrakeCatapult.transform.rotation;
        startRotation_RightBrake = rightBrakeCatapult.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        RestartBallPosition(KeyCode.R);
        ShowSpeedDistanceMassAboutBall(textInfo.GetComponent(typeof(TextMesh)) as TextMesh, this.GetComponent<Rigidbody>(),
            startPosition_Ball,this.transform.position);
        mainPartAngle = mainPartOfCatapult.transform.rotation.w;
        mainPartAngleRadius = mainPartOfCatapult.transform.rotation.z;
        Debug.Log("");
    }

    private void RestartBallPosition(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            transform.position = startPosition_Ball;
            arm.transform.rotation = startRotation_Arm;
            bodyCatapult.transform.rotation = startRotation_Base;
            RestartBrakeCatapultPosition();
        }
    }
    private void RestartBrakeCatapultPosition()
    {
        leftBrakeCatapult.transform.rotation = startRotation_LeftBrake;
        rightBrakeCatapult.transform.rotation = startRotation_RightBrake;
    }
    private void ShowSpeedDistanceMassAboutBall(TextMesh textmesh, Rigidbody rb,Vector3 startballposition, Vector3 endballposition)
    {
        float speed = rb.velocity.magnitude;
        float distance = Vector3.Distance(startballposition, endballposition);
        textmesh.text = "Mass = " + rb.mass.ToString();
        textmesh.text += "\nSpeed= " + speed.ToString("n2");
        textmesh.text += "\nDistance= " + distance.ToString("n2");

    }
   
}
