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
        
        

    }

    // Update is called once per frame
    void Update()
    {
        float x_position = wall_position.x - (Mathf.Abs(start_camera_position.x) - Mathf.Abs(wall_position.x));
       
        Debug.Log("roznica na kamerze : " + x_position.ToString());
        targetCamera.transform.position = new Vector3( wall_position.x - 0.1f
                                        , wall.transform.position.y + 3
                                        , wall.transform.position.z);
        Debug.Log("pozycja muru :"
            + " X=" + wall_position.x.ToString()
            + " Y=" + wall_position.y.ToString()
            + " Z=" + wall_position.z.ToString());

        Debug.Log("pozycja kamery :"
            + " X=" + targetCamera.transform.localPosition.x.ToString()
            + " Y=" + targetCamera.transform.localPosition.y.ToString()
            + " Z=" + targetCamera.transform.localPosition.z.ToString());
    }
}
