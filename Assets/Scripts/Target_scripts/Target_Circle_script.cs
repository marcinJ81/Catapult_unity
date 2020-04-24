using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Target_Circle_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetCircleObject;
    public float speed = 5f;
        
    private readonly IMoveCircle movecircle;
    public Target_Circle_script()
    {
        this.movecircle = new SimpleChangingObjectsPosition();
    }
    // Update is called once per frame
    void Update()
    {
        KeyCode key = KeyDetecion.KeysDown().Any() ? KeyDetecion.KeysDown().First() : KeyCode.AltGr;
        this.movecircle.MoveCircle( key, speed, Time.deltaTime, targetCircleObject);
    }
}



    