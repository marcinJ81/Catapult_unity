using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMethods : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topGate;

    private readonly IObjectControl moveObject;
    public GateMethods()
    {
        this.moveObject = new ObjectControl(new ChangeObjectPosition());
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        moveObject.MoveForwardObject(new Vector3(5f, 0f, 0f), topGate, KeyCode.W, 104.0f, 12f, Time.fixedDeltaTime);
        moveObject.MoveForwardObject(new Vector3(-5f, 0f, 0f) , topGate, KeyCode.S, 104f, 12f, Time.fixedDeltaTime);
    }
}
