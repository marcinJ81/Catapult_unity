using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    Camera Mcam, Tcam, Bcam;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -6);
        StartCoroutine(stopParam());
        Mcam = GameObject.Find("Main_Cam").GetComponent<Camera>();
        Tcam = GameObject.Find("Target_Cam").GetComponent<Camera>();
        Bcam = GameObject.Find("Ball_Cam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("klawisz c :" + Input.GetKeyDown(KeyCode.C).ToString());
            if (Mcam.enabled || Bcam.enabled)
            {
                Tcam.enabled = true;
                Mcam.enabled = false;
                Bcam.enabled = false;
            }               
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("klawisz D :" + Input.GetKeyDown(KeyCode.D).ToString());
            if (Tcam.enabled || Bcam.enabled)
            {
                Mcam.enabled = true;
                Tcam.enabled = false;
                Bcam.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Mcam.enabled || Tcam.enabled)
            {
                Bcam.enabled = true;
                Mcam.enabled = false;
                Tcam.enabled = false;
            }
        }
    }

    IEnumerator stopParam()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
