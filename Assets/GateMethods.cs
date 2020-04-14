using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMethods : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topGate;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        MoveForwardObject(new Vector3(5f, 0f, 0f), topGate, KeyCode.W, 104.0f, 12f);
        MoveForwardObject(new Vector3(-5f, 0f, 0f) , topGate, KeyCode.S, 104f, 12f);
    }


    private void MoveForwardObject(Vector3 velocity, GameObject gameobject, KeyCode key, float xmax,float xmin)
    {
        if (Input.GetKey(key))
        {
                
            var rb = gameobject.GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            if (velocity.x < 0)
            {
                if (((rb.transform.position.x > xmin) && (rb.transform.position.x < xmax)))
                {
                    rb.MovePosition(gameobject.transform.position - velocity.x * velocity * Time.fixedDeltaTime);
                }
                else
                {
                    if(rb.transform.position.x < xmin)
                        rb.MovePosition(gameobject.transform.position + velocity.x * velocity * Time.fixedDeltaTime);
                    else
                        rb.MovePosition(gameobject.transform.position - velocity.x * velocity * Time.fixedDeltaTime);
                }
            }
            else
            {
                if (((rb.transform.position.x < xmax) && (rb.transform.position.x > xmin)))
                {
                    rb.MovePosition(gameobject.transform.position + velocity.x * velocity * Time.fixedDeltaTime);
                }
                else
                {
                    if(rb.transform.position.x > xmax)
                        rb.MovePosition(gameobject.transform.position - velocity.x * velocity * Time.fixedDeltaTime);
                    else
                        rb.MovePosition(gameobject.transform.position + velocity.x * velocity * Time.fixedDeltaTime);
                }
            }
        }
    }
}
