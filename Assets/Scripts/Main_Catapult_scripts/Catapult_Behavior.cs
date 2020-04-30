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
    // Start is called before the first frame update
    public Catapult_Behavior()
    {
       
    }

    private void Awake()
    {
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
    void Start()
    {
      //  StartCoroutine(stopParam());

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
        if(throwBall == null)
            SetValueToThrowningBall();
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

    
    
}





