using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveCircle
{
    void MoveCircle(KeyCode key, float speed, float deltatime, GameObject targetCircleObject);
}
public class SimpleChangingObjectsPosition : IMoveCircle
{
    public void MoveCircle(KeyCode key, float speed, float deltatime, GameObject targetCircleObject)
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