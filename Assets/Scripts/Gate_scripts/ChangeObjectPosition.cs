using UnityEngine;
using System.Collections;

public interface IObjectControl
{
    void MoveForwardObject(Vector3 velocity, GameObject gameobject, KeyCode key, float xmax, float xmin,float fixedTime);
}
public class ObjectControl : IObjectControl
{
    private readonly IChangeObjectPosition moveObject;

    public ObjectControl(IChangeObjectPosition moveObject)
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
                    moveObject.MoveForwadBack(velocity, rb, gameobject, false, fixedTime);
                }
                else
                {
                    if (rb.transform.position.x < xmin)
                    {
                        moveObject.MoveForwadBack(velocity, rb, gameobject, true, fixedTime);
                    }

                    else
                    {
                        moveObject.MoveForwadBack(velocity, rb, gameobject, false, fixedTime);
                    }
                }
            }
            else
            {
                if (((rb.transform.position.x < xmax) && (rb.transform.position.x > xmin)))
                {
                    moveObject.MoveForwadBack(velocity, rb, gameobject, true, fixedTime);
                }
                else
                {
                    if (rb.transform.position.x > xmax)
                    {
                        moveObject.MoveForwadBack(velocity, rb, gameobject, false, fixedTime);
                    }

                    else
                    {
                        moveObject.MoveForwadBack(velocity, rb, gameobject, true, fixedTime);
                    }
                }
            }
        }
    }
}
public class ChangeObjectPosition : IChangeObjectPosition
{
    public void MoveForwadBack(Vector3 velocity, Rigidbody moveObject, GameObject gameobject, bool forward, float fixTime)
    {
        if (forward)
        {
            moveObject.MovePosition(gameobject.transform.position + velocity.x * velocity * fixTime);
        }
        else
        {
            moveObject.MovePosition(gameobject.transform.position - velocity.x * velocity * fixTime);
        }
    }
}
public interface IChangeObjectPosition
{
    void MoveForwadBack(Vector3 velocity, Rigidbody moveObject, GameObject gameobject, bool forward, float fixTime);
}
