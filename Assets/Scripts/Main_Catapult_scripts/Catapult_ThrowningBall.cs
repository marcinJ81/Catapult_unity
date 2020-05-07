using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowBall
{
    void ThrowBall(KeyCode key, Vector3 target, Vector3 origin, float time);
    void ThrowBall(KeyCode key, Vector3 target, Vector3 origin, float time, float rotationX);
}
public class Catapult_ThrowningBall : IThrowBall
{
    private float Vr = 0f;
    private Rigidbody rbBall;
    private GameObject ball_gameObject;
    private GameObject mainPart;

    public Catapult_ThrowningBall(float vr,  GameObject ball_gameObject, GameObject mainPart)
    {
        Vr = vr;
        this.ball_gameObject = ball_gameObject;
        rbBall = this.ball_gameObject.GetComponent<Rigidbody>();
        this.mainPart = mainPart;
    }

   

    public void ThrowBall(KeyCode key, Vector3 target, Vector3 origin, float time)
    {
        Vector3 Vo = CalculateVelocity(target, origin, time);

        if (Input.GetKeyDown(key))
        {
            //angularVelocity mierzy predkosc katowa, stopnie na sekunde
            Vr = Vr == 0 ? -6.0f : -Vr;
            this.mainPart.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, Vr);
            rbBall.MovePosition(this.ball_gameObject.transform.position + 0.1f * Vo * time);
        }
    }

    public void ThrowBall(KeyCode key, Vector3 target, Vector3 origin,float time, float rotationX)
    {
        if (Input.GetKeyDown(key))
        {
                Debug.Log("Rotacja w zakresie" + rotationX.ToString());

                Vr = Vr == 0 ? -6.0f : -Vr;
                this.mainPart.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, Vr);
        }
    }

    private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
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
    private void ShootTheTarget(float speed, GameObject target, GameObject ball, Vector3 startPosition, KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Vector3 velocity = new Vector3(speed, 0f, 0f);
            var rb = ball.GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.MovePosition(CalculateVelocity(target.transform.position, startPosition, Time.deltaTime));
        }
    }
}
