using System.Diagnostics.Tracing;
using UnityEngine;
using static TempValueCamera;

public class ExitDetected : MonoBehaviour
{
    private Camera cam;
    private bool onSpriteDown = false;
    private ExitDetected tempValue;
    private int numWall;

    public string Name;

    private void OnMouseDown()
    {
        cam = Camera.main;
        if (!cam.GetComponent<RotateRoom>().cameraMove)
        {
            SetValue();
            GameObject.Find("RoomChanger").GetComponent<Scenes>().LoadRoom(Name);
            EngineSwipe.SwipeEvent -= cam.GetComponent<RotateRoom>().OnSwipe;
        }
    }

    private void SetValue()
    {
        TempValueCamera.CameraPosition = cam.transform.position;
        TempValueCamera.CameraRotate = cam.transform.eulerAngles;
        TempValueCamera.CurrentAngle = cam.GetComponent<RotateRoom>().currentAngle;
        TempValueCamera.OnSpriteDown = onSpriteDown;
        TempValueCamera.NumWall = GameObject.FindGameObjectWithTag("WallWithExit").GetComponent<UpWall>().numWall;
    }

    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnMouseDown();
    }
}
