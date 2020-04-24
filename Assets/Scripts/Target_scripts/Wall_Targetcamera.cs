using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_camera : MonoBehaviour
{
    public GameObject wall;
    private Camera targetCamera;
    private Vector3 wall_position;
    private Vector3 start_camera_position;
    // Start is called before the first frame update
    void Start()
    {
        wall_position = wall.transform.localPosition;
        start_camera_position = transform.localPosition;
        targetCamera = GameObject.Find("Target_Cam").GetComponent<Camera>();
       
        float x_position = wall_position.x - 0.1f;
        targetCamera.transform.localPosition = new Vector3(x_position
                                        , wall.transform.localPosition.y + 3
                                        , wall.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
