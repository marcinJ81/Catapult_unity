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

    public List<GameObject> ListForMainCatapult()
    {
        List<GameObject> result = new List<GameObject>();
        result.Add(this.target_position);
        result.Add(this.ball_gameObject);
        result.Add(this.brake_object);
        result.Add(this.base_object);
        result.Add(this.left_arm_break);
        result.Add(this.right_arm_break);
        result.Add(this.arm_object);
        result.Add(this.ground_target_position);
        return result;
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
    List<GameObject> ListForMainCatapult();
}
