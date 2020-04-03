using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_script : MonoBehaviour
{
    public GameObject ground;
    private float z_min = -0.3f;
    private float z_max = 0.3f;
    private float x_min = -0.4f;
    private float x_max = 0.4f;
    void Start()
    {
        transform.parent = ground.transform;
        Debug.Log("X -> " + transform.localPosition.x.ToString());
        Debug.Log("Z -> " + transform.localPosition.z.ToString());
        transform.localPosition = RandomWallPosition();
        
    }
    private Vector3 RandomWallPosition()
    {
        float randomX;
        float randomZ;

        randomX = Random.Range(x_min, x_max);
        randomZ = Random.Range(z_min, z_max);
        Vector3 wallPosition = new Vector3(randomX, 5, randomZ);
        return wallPosition;
    }
}
