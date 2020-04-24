using UnityEngine;
using System.Collections;

public interface IObjectControl
{
    void MoveForwardObject(Vector3 velocity, GameObject gameobject, KeyCode key, float xmax, float xmin,float fixedTime);
}
public class Gate_ChangeObjectPosition : IObjectControl
{
    private readonly IMoveGate moveObject;

    public Gate_ChangeObjectPosition(IMoveGate moveObject)
    {
        this.moveObject = moveObject;
    }
    public void MoveForwardObject(Vector3 velocity, GameObject gameobject, KeyCode key, float xmax, float xmin, float fixedTime)
    {
        if (Input.GetKey(key))
        {
            var rb = gameobject.GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            if (velocity.x < 0)
            {
                if (((rb.transform.position.x > xmin) && (rb.transform.position.x < xmax)))
                {
                    moveObject.MoveRigidBodyForwadBack(velocity, rb, gameobject, false, fixedTime);
                }
                else
                {
                    if (rb.transform.position.x < xmin)
                    {
                        moveObject.MoveRigidBodyForwadBack(velocity, rb, gameobject, true, fixedTime);
                    }

                    else
                    {
                        moveObject.MoveRigidBodyForwadBack(velocity, rb, gameobject, false, fixedTime);
                    }
                }
            }
            else
            {
                if (((rb.transform.position.x < xmax) && (rb.transform.position.x > xmin)))
                {
                    moveObject.MoveRigidBodyForwadBack(velocity, rb, gameobject, true, fixedTime);
                }
                else
                {
                    if (rb.transform.position.x > xmax)
                    {
                        moveObject.MoveRigidBodyForwadBack(velocity, rb, gameobject, false, fixedTime);
                    }

                    else
                    {
                        moveObject.MoveRigidBodyForwadBack(velocity, rb, gameobject, true, fixedTime);
                    }
                }
            }
        }
    }
}

