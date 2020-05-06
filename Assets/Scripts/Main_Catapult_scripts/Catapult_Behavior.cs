using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity;
using UnityEngine;

public class Catapult_Behavior : MonoBehaviour
{
    public GameObject target_position;
    public GameObject ball_gameObject;
    public GameObject brake_object;
    public GameObject mainPartCatapult;
    public GameObject left_arm_break;
    public GameObject right_arm_break;
    public GameObject arm_object;
    public GameObject ground_target_position;
    public float Vr =  0f;

    private Vector3 start_ball_position;
    private IEnabledCamera setCamera;
    private IRotationCatapult rotateCapult;
    private IThrowBall throwBall;

    private Balistic_RenderLine throwLine;
    private float g;
    public float radianAngle;
    private void Awake()
    {
        //  StartCoroutine(stopParam());
        throwLine = new Balistic_RenderLine();
        g = Mathf.Abs(Physics2D.gravity.y);
        //
        SetValueCameraObject();
        start_ball_position = ball_gameObject.transform.position;
        SetValueRotateCatapultObject();
        SetValueToThrowningBall();
    }
    private void SetValueRotateCatapultObject()
    {
        this.rotateCapult = new Catapult_TurnOver(mainPartCatapult, left_arm_break, right_arm_break, brake_object);
    }
    private void SetValueCameraObject()
    {
        this.setCamera = new Camera_Definitions(
           GameObject.Find("Main_Cam").GetComponent<Camera>(),
           GameObject.Find("Target_Cam").GetComponent<Camera>(),
           GameObject.Find("Ball_Cam").GetComponent<Camera>());
    }
    private void SetValueToThrowningBall()
    {
        this.throwBall = new Catapult_ThrowningBall(Vr, ball_gameObject, mainPartCatapult);
    }
    // Update is called once per frame
    void Update()
    {
        //change camera
        if (setCamera == null)
            SetValueCameraObject();
        setCamera.SetEnabledCamera(KeyCode.Alpha1, false, true, false);
        setCamera.SetEnabledCamera(KeyCode.Alpha2, true, false, false);
        setCamera.SetEnabledCamera(KeyCode.Alpha3, false, false, true);

        //Throw ball
        if (throwBall == null)
        {
            SetValueToThrowningBall();
        }
        fly();
        throwBall.ThrowBall(KeyCode.Space,target_position.transform.position, ball_gameObject.transform.position,Time.deltaTime,
        mainPartCatapult.transform.localRotation.x);

        //use keys arrow to rotate
        if (rotateCapult == null)
            SetValueRotateCatapultObject();
        rotateCapult.RotationLeftORightGameObject(mainPartCatapult.transform.rotation.w, KeyCode.LeftArrow, 0, -1, 0.1f);
        rotateCapult.RotationLeftORightGameObject(mainPartCatapult.transform.rotation.w, KeyCode.RightArrow, 0, 1, 0.1f);
    }
    IEnumerator stopParam()
    {
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    void fly()
    {
        var rb = ball_gameObject.GetComponent<Rigidbody>();
        if(Input.GetKey(KeyCode.Space))
       {
            rb.MovePosition(CalculateArcArray()[1]);
       }
    }
    public Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[throwLine.resolution + 1];

        radianAngle = Mathf.Deg2Rad * throwLine.angle;

        Debug.Log("radianAngle=" + radianAngle.ToString());
        Debug.Log("Velocity=" + throwLine.velocity.ToString());
        Debug.Log("Mathf.Sin(2 * radianAngle)=" + Mathf.Sin(2 * radianAngle).ToString());
        Debug.Log("throwLine.g=" + g.ToString());

        float maxDistance = (throwLine.velocity * throwLine.velocity * Mathf.Sin(2 * radianAngle)) / g;
        Debug.Log("maxDistance=" + maxDistance.ToString());
        for (int i = 0; i <= throwLine.resolution; i++)
        {
            float t = (float)i / (float)throwLine.resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }
    public Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        
        
        Debug.Log("X=" + x.ToString());
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / 
            (2 * throwLine.velocity * throwLine.velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        Debug.Log("Y=" + y.ToString());
        return new Vector3(x, y,0);
    }

}





