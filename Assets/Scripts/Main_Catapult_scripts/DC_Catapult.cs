using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC_Catapult : MonoBehaviour, IDCContainerList
{
    public GameObject target_position;
    public GameObject ball_gameObject;
    public GameObject brake_object;
    public GameObject base_object;
    public GameObject left_arm_break;
    public GameObject right_arm_break;
    public GameObject arm_object;
    public GameObject ground_target_position;

    private List<DCDTO> ListDependency;

    public DC_Catapult()
    {
        ListDependency = new List<DCDTO>()
        {
            new DCDTO() { objectName = "tartget_position", objectValue = target_position },
            new DCDTO() { objectName = "ball_gameObject", objectValue = ball_gameObject },
            new DCDTO() { objectName = "brake_object", objectValue = brake_object },
            new DCDTO() { objectName = "left_arm_break", objectValue = left_arm_break },
            new DCDTO() { objectName = "base_object", objectValue = base_object },
            new DCDTO() { objectName = "right_arm_break", objectValue = right_arm_break },
            new DCDTO() { objectName = "arm_object", objectValue = arm_object },
            new DCDTO() { objectName = "ground_target_position", objectValue = ground_target_position }
        };
    }
    
    public List<DCDTO> ListObject()
    {
        return ListDependency;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
public interface IDCContainerList
{
    List<DCDTO> ListObject();
}

public class DCDTO
{
   public string objectName { get; set; }
   public GameObject objectValue { get; set; }
}
