using UnityEngine;
using System.Collections;

public interface IEnabledCamera
{
    void SetEnabledCamera(KeyCode key, bool MainCam, bool TargetCam, bool BallCam);
}
public class Camera_Definitions : IEnabledCamera
{
    private Camera MainCamera;
    private Camera TargetCamera;
    private Camera BallCamera;

    public Camera_Definitions() { }
    public Camera_Definitions(Camera mainCamera, Camera targetCamera, Camera ballCamera)
    {
        MainCamera = mainCamera;
        TargetCamera = targetCamera;
        BallCamera = ballCamera;
    }

    public void SetEnabledCamera(KeyCode key, bool MainCam, bool TargetCam, bool BallCam)
    {
        if (Input.GetKeyDown(key))
        {
            MainCamera.enabled = MainCam;
            TargetCamera.enabled = TargetCam;
            BallCamera.enabled = BallCam;
        }
    }
}
