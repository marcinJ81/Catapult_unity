﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Catapult_Behavior : MonoBehaviour
{
    private Camera MainCamera, TargetCamera, BallCamera;
    
    public GameObject target_position;
    public GameObject ball_gameObject;
    public GameObject brake_object;
    public GameObject base_object;
    public GameObject left_arm_break;
    public GameObject right_arm_break;
    public GameObject arm_object;
    public GameObject ground_target_position;
    public float Vr =  0f;

   
    private Vector3 start_ball_position;
    private IEnabledCamera setCamera;
    private IRotationCatapult rotateCapult;
    // Start is called before the first frame update
    public Catapult_Behavior()
    {
           
    }
    void Start()
    {
        StartCoroutine(stopParam());
        MainCamera = GameObject.Find("Main_Cam").GetComponent<Camera>();
        TargetCamera = GameObject.Find("Target_Cam").GetComponent<Camera>();
        BallCamera = GameObject.Find("Ball_Cam").GetComponent<Camera>();
        this.setCamera = new Camera_Definitions(MainCamera,TargetCamera,BallCamera);
        start_ball_position = ball_gameObject.transform.position;
        this.rotateCapult = new Catapult_TurnOver(base_object, left_arm_break, right_arm_break, brake_object);
    }

    // Update is called once per frame
    void Update()
    {
        //change camera
        setCamera.SetEnabledCamera(KeyCode.Alpha1, false, true, false);
        setCamera.SetEnabledCamera(KeyCode.Alpha2, true, false, false);
        setCamera.SetEnabledCamera(KeyCode.Alpha3, false, false, true);

        //Throw ball
        ThrowBall(KeyCode.Space,target_position.transform.position, ball_gameObject.transform.position,1.0f, ball_gameObject);
        //MoveForwardObject(15.0f, ball_gameObject, KeyCode.Space);

        //use keys arrow to rotate
        rotateCapult.RotationLeftORightGameObject( base_object.transform.rotation.w, KeyCode.LeftArrow, 0, -1, 0.1f);
        rotateCapult.RotationLeftORightGameObject(base_object.transform.rotation.w, KeyCode.RightArrow, 0, 1, 0.1f);
    }
   
  
    private void ThrowBall(KeyCode key, Vector3 target, Vector3 origin, float time, GameObject throwBall)
    {
        Vector3 Vo = CalculateVelocity(target, origin, time);

        if (Input.GetKeyDown(key))
        {
            //angularVelocity mierzy predkosc katowa, stopnie na sekunde
            Vr = Vr == 0 ? -6.0f : -Vr;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, Vr);
            var rb = throwBall.GetComponent<Rigidbody>();
            rb.MovePosition(throwBall.transform.position + 0.1f * Vo *time);
        }
        
    }
    private void MoveForwardObject(float speed, GameObject gameobject, KeyCode key)
    {
        if (Input.GetKeyDown(key))
        { 
            Vector3 velocity = new Vector3(speed,0f, 0f);
            var rb = gameobject.GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            //rb.MovePosition(gameobject.transform.position + speed * velocity * Time.fixedDeltaTime);
        }
    }
    private void ShootTheTarget(float speed, GameObject target,GameObject ball,Vector3 startPosition, KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Vector3 velocity = new Vector3(speed, 0f, 0f);
            var rb = ball.GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.MovePosition(CalculateVelocity(target.transform.position,startPosition,Time.deltaTime));
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
      //  Debug.Log("target : " + target.x.ToString() + ";" + target.y.ToString() + ";" + target.z.ToString());
      // Debug.Log("origin : " + origin.x.ToString() + ";" + origin.y.ToString() + ";" + origin.z.ToString());
        Vector3 distanceXZ = distance;
      //  Debug.Log("distance : " + distance.x.ToString() + ";" + distance.y.ToString() +";"+ distance.z.ToString());
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude; //dlugosc vectora
      //  Debug.Log("distanceXZ.magnitude : " + Sxz.ToString());
        float Vxz = Sxz / (time * 10000);
     //   Debug.Log("time : " + time.ToString());
     //   Debug.Log("Vxz : " + Vxz.ToString());
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

     //   Debug.Log("resultat : " + result.x.ToString() + ";" + result.y.ToString() + ";" + result.z.ToString());
        return result;
    }
    private Vector3 CalculteHalfDistance(Vector3 startPosition, Vector3 emdPosition, float time)
    {
        Vector3 result = new Vector3(0f, 0f, 0f);

        return result;
    }
}





