using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Circle_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetCircleObject;
    public GameObject groundObject;

    private Vector3 circleTargetPsoition;
    void Start()
    {
        circleTargetPsoition = targetCircleObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
