using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotationCatapult
{
    void RotationLeftORightGameObject(float rotationValue, KeyCode key, int x_value, int y_value, float angle_value);
}
public class Catapult_TurnOver : IRotationCatapult
{
    private Dictionary<string, float> MaxMainArmXAngle;
    private GameObject brake_object;
    private GameObject base_object;
    private GameObject left_arm_break;
    private GameObject right_arm_break;

    private Catapult_TurnOver()
    {
        this.MaxMainArmXAngle = new Dictionary<string, float>();
        this.MaxMainArmXAngle.Add("WLmax", 0.697f);
        this.MaxMainArmXAngle.Add("WRmax", 0.7042f);
    }

    public Catapult_TurnOver(GameObject base_object, GameObject left_arm_break, GameObject right_arm_break, GameObject brake_object)
        :this()
    {
        this.base_object = base_object;
        this.left_arm_break = left_arm_break;
        this.right_arm_break = right_arm_break;
        this.brake_object = brake_object;
    }

    public void RotationLeftORightGameObject( float rotationValue, KeyCode key, int x_value, int y_value, float angle_value)
    {
        //not working good
        if (Input.GetKey(key))
        {
            if (y_value > 0)
            {
                //right arrow
                if ((rotationValue > MaxMainArmXAngle["WLmax"]) || (rotationValue < MaxMainArmXAngle["WRmax"]))
                {
                    SetNewAngle( x_value, y_value, angle_value);
                }
            }
            else
            {
                //left arrow
                if ((rotationValue > MaxMainArmXAngle["WLmax"]) || (rotationValue < MaxMainArmXAngle["WRmax"]))
                {
                    SetNewAngle( x_value, y_value, angle_value);
                }
            }
            // Debug.Log("kąt Wartość baza = " + base_object.transform.rotation.w.ToString());
            // Debug.Log("kąt Wartość = " + arm_object.transform.rotation.w.ToString());
        }
    }
    private void SetNewAngle(int x_value, int y_value, float angle_value)
    {
        brake_object.transform.Rotate(new Vector3(x_value, y_value), angle_value);
        base_object.transform.Rotate(new Vector3(x_value, y_value), angle_value);
        left_arm_break.transform.Rotate(new Vector3(x_value, y_value), angle_value);
        right_arm_break.transform.Rotate(new Vector3(x_value, y_value), angle_value);
    }
}
