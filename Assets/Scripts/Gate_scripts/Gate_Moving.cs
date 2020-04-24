using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMoveGate
{
    void MoveRigidBodyForwadBack(Vector3 velocity, Rigidbody moveObject, GameObject gameobject, bool forward, float fixTime);
}
public class Gate_Moving : IMoveGate
{
    public void MoveRigidBodyForwadBack(Vector3 velocity, Rigidbody moveObject, GameObject gameobject, bool forward, float fixTime)
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

