using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveCircle
{
    void MoveCircle(KeyCode key, float speed, float deltatime, GameObject targetCircleObject);
}
public class SimpleChangingObjectsPosition : IMoveCircle
{
    private Model_ControlsCircleGroundTarget definedControlers;
    public SimpleChangingObjectsPosition()
    {
       this.definedControlers = new Model_ControlsCircleGroundTarget();
    }
    public void MoveCircle(KeyCode key, float speed, float deltatime, GameObject targetCircleObject)
    {
        if (key == definedControlers.getDefineKeys.Left_key)
        {
            targetCircleObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (key == definedControlers.getDefineKeys.Right_key)
        {
            targetCircleObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (key == definedControlers.getDefineKeys.Back_key)
        {
            targetCircleObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (key == definedControlers.getDefineKeys.Forward_key)
        {
            targetCircleObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}