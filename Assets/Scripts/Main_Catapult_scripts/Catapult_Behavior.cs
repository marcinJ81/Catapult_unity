using System;
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

    private Dictionary<string, float> MaxMainArmXAngle;
    private Vector3 start_ball_position;
    // Start is called before the first frame update
    public Catapult_Behavior()
    {
        this.MaxMainArmXAngle = new Dictionary<string, float>();
        this.MaxMainArmXAngle.Add("WLmax", 0.697f);
        this.MaxMainArmXAngle.Add("WRmax", 0.7042f);       
    }
    void Start()
    {
        StartCoroutine(stopParam());
        MainCamera = GameObject.Find("Main_Cam").GetComponent<Camera>();
        TargetCamera = GameObject.Find("Target_Cam").GetComponent<Camera>();
        BallCamera = GameObject.Find("Ball_Cam").GetComponent<Camera>();
        start_ball_position = ball_gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //change camera
        SetEnabledCamera(KeyCode.Alpha1, false, true, false);
        SetEnabledCamera(KeyCode.Alpha2, true, false, false);
        SetEnabledCamera(KeyCode.Alpha3, false, false, true);

        //Throw ball
        ThrowBall(KeyCode.Space,target_position.transform.position, ball_gameObject.transform.position,1.0f);
        //MoveForwardObject(15.0f, ball_gameObject, KeyCode.Space);

        //use keys arrow to rotate
        RotationLeftORightGameObject(brake_object, base_object.transform.rotation.w, KeyCode.LeftArrow, 0, -1, 0.1f);
        RotationLeftORightGameObject(brake_object, base_object.transform.rotation.w, KeyCode.RightArrow, 0, 1, 0.1f);
  
    }
    private void RotationLeftORightGameObject(GameObject catapultTopBreak, float rotationValue, KeyCode key, int x_value, int y_value, float angle_value)
    { 
        //not working good
        if (Input.GetKey(key))
        {
            if (y_value > 0)
            {
                //right arrow
                if ((rotationValue > MaxMainArmXAngle["WLmax"]) || (rotationValue < MaxMainArmXAngle["WRmax"]))
                {
                    SetNewAngle(catapultTopBreak, x_value, y_value, angle_value);
                }
            }
            else
            {
                //left arrow
                if ((rotationValue > MaxMainArmXAngle["WLmax"]) || (rotationValue < MaxMainArmXAngle["WRmax"]))
                {
                    SetNewAngle(catapultTopBreak, x_value, y_value , angle_value);
                }
            }
           // Debug.Log("kąt Wartość baza = " + base_object.transform.rotation.w.ToString());
           // Debug.Log("kąt Wartość = " + arm_object.transform.rotation.w.ToString());
        }
    }
    private void SetNewAngle(GameObject catapultTopBreak, int x_value, int y_value, float angle_value)
    {
        catapultTopBreak.transform.Rotate(new Vector3(x_value, y_value), angle_value);
        base_object.transform.Rotate(new Vector3(x_value, y_value), angle_value);
        left_arm_break.transform.Rotate(new Vector3(x_value, y_value), angle_value);
        right_arm_break.transform.Rotate(new Vector3(x_value, y_value), angle_value);
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
        //Vector3 Vo = CalculateVelocity(target, origin, time);

        if (Input.GetKeyDown(key))
        {
            //angularVelocity mierzy predkosc katowa, stopnie na sekune
            Vr = Vr == 0 ? -6.0f : -Vr;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, Vr);
           // GetComponent<Rigidbody>().AddForce();
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
        Debug.Log("target : " + target.x.ToString() + ";" + target.y.ToString() + ";" + target.z.ToString());
        Debug.Log("origin : " + origin.x.ToString() + ";" + origin.y.ToString() + ";" + origin.z.ToString());
        Vector3 distanceXZ = distance;
        Debug.Log("distance : " + distance.x.ToString() + ";" + distance.y.ToString() +";"+ distance.z.ToString());
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude; //dlugosc vectora
        Debug.Log("distanceXZ.magnitude : " + Sxz.ToString());
        float Vxz = Sxz / (time * 10000);
        Debug.Log("time : " + time.ToString());
        Debug.Log("Vxz : " + Vxz.ToString());
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        Debug.Log("resultat : " + result.x.ToString() + ";" + result.y.ToString() + ";" + result.z.ToString());
        return result;
    }
    private Vector3 CalculteHalfDistance(Vector3 startPosition, Vector3 emdPosition, float time)
    {
        Vector3 result = new Vector3(0f, 0f, 0f);

        return result;
    }
}





