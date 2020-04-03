using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_camera : MonoBehaviour
{
    public GameObject wall;
    private Vector3 wall_position;
    private Vector3 start_camera_position;
    // Start is called before the first frame update
    void Start()
    {
        wall_position = wall.transform.localPosition;
        start_camera_position = transform.localPosition;
        Debug.Log("pozycja muru :"
            + " X=" + wall_position.x.ToString()
            + " Y=" + wall_position.y.ToString()
            + " Z=" + wall_position.z.ToString());
        transform.position = new Vector3(wall.transform.position.x 
                                        ,wall.transform.position.y + 3
                                        ,wall.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
