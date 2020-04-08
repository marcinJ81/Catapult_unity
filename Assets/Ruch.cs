using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    private Camera MainCamera, TargetCamera, BallCamera;
    
    public GameObject target_position;
    public GameObject ball_position;
    public GameObject brake_object;
    public GameObject arm_object;
    public GameObject left_arm_break;
    public GameObject right_arm_break;
    public float Vr =  0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stopParam());
        MainCamera = GameObject.Find("Main_Cam").GetComponent<Camera>();
        TargetCamera = GameObject.Find("Target_Cam").GetComponent<Camera>();
        BallCamera = GameObject.Find("Ball_Cam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //change camera
        SetEnabledCamera(KeyCode.Alpha1, false, true, false);
        SetEnabledCamera(KeyCode.Alpha2, true, false, false);
        SetEnabledCamera(KeyCode.Alpha3, false, false, true);
        //Throw ball
        ThrowBall(KeyCode.Space,target_position.transform.position,ball_position.transform.position,1.0f);
       
        //use keys arrow to rotate
        RotationLeftORightGameObject(brake_object, KeyCode.LeftArrow, 0, -1, 0.1f);
        RotationLeftORightGameObject(brake_object, KeyCode.RightArrow, 0, 1, 0.1f);
    }
    private void RotationLeftORightGameObject(GameObject catapultBody,KeyCode key, int x_value, int y_value, float angle_value)
    {
        if (Input.GetKey(key))
        {
            catapultBody.transform.Rotate(new Vector3(x_value, y_value), angle_value);  
            arm_object.transform.Rotate(new Vector3(x_value, y_value), angle_value);
            left_arm_break.transform.Rotate(new Vector3(x_value, y_value), angle_value);
            right_arm_break.transform.Rotate(new Vector3(x_value, y_value), angle_value);

            Debug.Log("kąt Wartość = " + arm_object.transform.rotation.w.ToString());
        }
    }

   private void SetEnabledCamera(KeyCode key, bool MainCam, bool TargetCam, bool BallCam)
    {
        if (Input.GetKeyDown(key))
        {
            MainCamera.enabled = MainCam;
            TargetCamera.enabled = TargetCam;
            BallCamera.enabled = BallCam;
        }
    }
    private void ThrowBall(KeyCode key, Vector3 target, Vector3 origin, float time)
    {
        Vector3 Vo = CalculateVelocity(target, origin, time);

        if (Input.GetKeyDown(key))
        {
            //angularVelocity mierzy predkosc katowa, stopnie na sekune
            Vr = Vr == 0 ? -6.0f : -Vr;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, Vr);   
        }
        
    }
    private void MoveForwardObject(float speed, GameObject gameobject, KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            float forwardSpeed = 1.0f;
            Vector3 velocity = new Vector3(0f, 0f, forwardSpeed);
            var rb = GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.MovePosition(transform.position + forwardSpeed * velocity * Time.fixedDeltaTime);
        }
    }
    IEnumerator stopParam()
    {
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude; //dlugosc vectora

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}





