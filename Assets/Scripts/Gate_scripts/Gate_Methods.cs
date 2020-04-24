using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Methods : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topGate;

    private readonly IObjectControl moveObject;
    public Gate_Methods()
    {
        this.moveObject = new Gate_ChangeObjectPosition(new Gate_Moving());
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
