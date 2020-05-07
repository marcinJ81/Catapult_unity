using UnityEngine;
using System.Collections;

public class Balistic_Calculation
{
    public float velocity
    {
        get {return velocity; }
        set { if (value > 0) velocity = value; }
    }
    public float angle;
   
    private float lengthpartOfTheDistance;
    private int distancePartNumber;
    private float g;
    private float radianAngle;
    private int resolution;
    private float maxDistance;

    public Balistic_Calculation(int resolution)
    {
        g = Mathf.Abs(Physics2D.gravity.y);
        if ((resolution == 0) || (resolution < 0))
        {
            this.resolution = 10;
        }
        else
        {
            this.resolution = resolution;
        }
        this.distancePartNumber = 0; 
    }
    public Vector3 CalculateArcOneVector(float velocity,  float angle,int partOfDistance)
    {
        if (partOfDistance < this.distancePartNumber)
        {
            return Vector3.zero;
        }
        Vector3 result;
        float radianangle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianangle)) / g;
        //get time for one part of maxdistance
        float time = CalculateTimeOfFly(velocity, radianangle, maxDistance) * (partOfDistance/resolution);
        //get length part of distance
        lengthpartOfTheDistance = maxDistance / resolution;
        result = CalculateArcPoint(time, lengthpartOfTheDistance);
        return result;
    }
    public Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;

        //Debug.Log("radianAngle=" + radianAngle.ToString());
        //Debug.Log("Velocity=" + throwLine.velocity.ToString());
        //Debug.Log("Mathf.Sin(2 * radianAngle)=" + Mathf.Sin(2 * radianAngle).ToString());
        //Debug.Log("throwLine.g=" + g.ToString());

        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;
        //  Debug.Log("maxDistance=" + maxDistance.ToString());
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }
    public Vector3 CalculateArcPoint(float t, float x)
    {
        //s = V*t
       // float x = t * maxDistance;
        
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) /
            (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        //  Debug.Log("Y=" + y.ToString());
        return new Vector3(x, y, 0);
    }

    public float CalculateTimeOfFly(float velocity, float radianangle, float maxdistance)
    {
        float timefly;
        timefly = maxdistance / velocity * Mathf.Cos(radianAngle);
        return timefly;
    }
}
