using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_script : MonoBehaviour
{
    public GameObject ground;
  
    void Start()
    {
        transform.parent = ground.transform;
        transform.localPosition = SRandomObjectPosition.GetRandomPosition();
    }
   
}
