using UnityEngine;
using System.Collections;

public class NewMonoBehaviour
{
    //Code from unity tutorial
    //https://learn.unity.com/project/catapult-physics-forces-and-energy
    //public void ThrowBall(Vector3 forceVector, float velocity)
    //{
    //    launched = true;
    //    cannonBall.transform.SetParent(null);
    //    cannonBall.rigidBody.constraints = RigidbodyConstraints.None;
    //    if (GameManager.GetInstance().CurrentPhysicsMode == PhysicsMode.Forces || GameManager.GetInstance().CurrentPhysicsMode == PhysicsMode.Energy)
    //    {
    //        cannonBall.rigidBody.useGravity = true;
    //    }
    //    cannonBall.rigidBody.AddForce(forceVector * (velocity * cannonBall.Mass), ForceMode.Impulse);
    //    cannonBall.inAir = true;
    //}

    //execute
    // float velocity = Velocity_At_Time_Of_Launch();
    //float ratio = ratio_Of_DEPE_Over_DGPE();
    //catapult.ThrowBall(catapult.launchVector.up, velocity);

    //definition
    //public float Velocity_At_Time_Of_Launch()
    //{
    //    float velocity = Mathf.Sqrt(((springK / cannonBall.Mass) * Mathf.Pow((catapult.DEFAULT_LAUNCH_ANGLE * Mathf.Deg2Rad), 2)) - (Physics.gravity.y * Mathf.Sqrt(2f)));
    //    return velocity;
    //}

    // Delta Time is equal to the Delta Vertical Velocity divided by the vertical acceleration (gravity)
    // Formula: ((vVertF - vVertI) / g)
    //private float CalculateDeltaTime()
    //{
    //    float velocity = Velocity_At_Time_Of_Launch();
    //    float vertVelocity = velocity * Mathf.Cos(catapult.DEFAULT_LAUNCH_ANGLE * Mathf.Deg2Rad);
    //    float vI = vertVelocity;
    //    float vF = -vertVelocity;
    //    float deltaV = vF - vI;
    //    float deltaTime = deltaV / Physics.gravity.y;
    //    uiController.physicsUIPanel.timeText.text = Math.Round(deltaTime, 2).ToString() + " s";
    //    return deltaTime;
    //}

    ///// <summary>
    ///// Distance is calculated using the horizontal component of velocity multiplies by delta time 
    ///// Formula: ( vIh * dt )
    ///// </summary>
    //public void CalculateDistance()
    //{
    //    float horizVelocity = Velocity_At_Time_Of_Launch() * Mathf.Sin(catapult.DEFAULT_LAUNCH_ANGLE * Mathf.Deg2Rad);
    //    float deltaTime = CalculateDeltaTime();
    //    float horizontalDistance = horizVelocity * deltaTime;

    //    // Stretch the distance gizmo to show the pre-calculated horizontal distance
    //    distanceGizmo.StretchGizmo(horizontalDistance);

    //    // Update the Distance Text on the UI Physics Info (Top Left UI)  
    //    uiController.physicsUIPanel.distanceText.text = Math.Round(horizontalDistance, 2).ToString() + " m";
    //}

    //// Force that is the combined Normal and Centrifugal force of the catapult spoon on the cannonball as the arm rises
    //// Formula: (Nx+Cx, Ny+Cy)
    //private Vector3 CalculateSVector()
    //{
    //    return (NormalVector() + CentrifugalVector()) * new Vector3(-1, 1, 0); // Multiply x by -1 to horizontally flip the S Vector to the catapult's local orientation
    //}
}
