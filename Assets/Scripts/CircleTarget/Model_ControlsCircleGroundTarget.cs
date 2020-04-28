using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_ControlsCircleGroundTarget : MonoBehaviour
{
    public KeyCode Forward_key { private get; set; }
    public KeyCode Back_key { private get; set; }
    public KeyCode Left_key { private get; set; }
    public KeyCode Right_key { private get; set; }

    private TargetControlerKeys targetControlerDefineKeys;
    public TargetControlerKeys getDefineKeys
    {
        get
        {
            if (this.targetControlerDefineKeys != null)
                return this.targetControlerDefineKeys;
            else
                return null;
        }        
    }
    public Model_ControlsCircleGroundTarget()
    {
        if (!SCheckKeyCode.CheckKeyCode(Forward_key))
        {
            this.Forward_key = KeyCode.UpArrow;
        }
        if (!SCheckKeyCode.CheckKeyCode(Back_key))
        {
            this.Back_key = KeyCode.DownArrow;
        }
        if (!SCheckKeyCode.CheckKeyCode(Left_key))
        {
            this.Left_key = KeyCode.LeftArrow;
        }
        if (!SCheckKeyCode.CheckKeyCode(Right_key))
        {
            this.Right_key = KeyCode.RightArrow;
        }

        this.targetControlerDefineKeys = new TargetControlerKeys(this.Forward_key, this.Back_key, this.Left_key, this.Right_key);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
public class TargetControlerKeys
{
    public TargetControlerKeys(KeyCode forward_key, KeyCode back_key, KeyCode left_key, KeyCode right_key)
    {
        Forward_key = forward_key;
        Back_key = back_key;
        Left_key = left_key;
        Right_key = right_key;
    }
    public KeyCode Forward_key { get; private set; }
    public KeyCode Back_key {  get; private set; }
    public KeyCode Left_key { get; private set; }
    public KeyCode Right_key { get; private set; }
}

