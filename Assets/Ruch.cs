using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    private Camera MainCamera, TargetCamera, BallCamera;
    
    public GameObject target_position;
    public GameObject ball_position;
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
        SetEnabledCamera(KeyCode.C, false, true, false);
        SetEnabledCamera(KeyCode.D, true, false, false);
        SetEnabledCamera(KeyCode.B, false, false, true);
        //Throw ball
        ThrowBall(KeyCode.Space,target_position.transform.position,ball_position.transform.position,1.0f);

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
            Debug.Log("Pozycja"
                + " X: " + Vo.x
                + " Y: " + Vo.y
                + " Z: " + Vo.z);
           
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





