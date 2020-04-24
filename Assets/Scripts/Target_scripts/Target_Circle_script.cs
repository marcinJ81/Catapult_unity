using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Target_Circle_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetCircleObject;
    public GameObject groundObject;

    private float speed = 5f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode key = KeyDetecion.KeysDown().Any() ? KeyDetecion.KeysDown().First() : KeyCode.P;
        MoveCircle( key, 5f, Time.deltaTime);
    }
    void MoveCircle(KeyCode key, float speed, float deltatime)
    {
        if (key == KeyCode.LeftArrow)
        {
            targetCircleObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (key == KeyCode.RightArrow)
        {
            targetCircleObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (key == KeyCode.DownArrow)
        {
            targetCircleObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (key == KeyCode.UpArrow)
        {
            targetCircleObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
   
}

    