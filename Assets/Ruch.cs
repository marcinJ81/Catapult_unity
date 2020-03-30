﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -6);
        StartCoroutine(stopParam());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator stopParam()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
