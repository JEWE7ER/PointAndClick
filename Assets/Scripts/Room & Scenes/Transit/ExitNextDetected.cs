using UnityEngine;
using static TempValueCamera;

public class ExitNextDetected : MonoBehaviour
{
    private Camera cam;
    private bool onSpriteDown = false;

    private void OnMouseDown()
    {
        cam = Camera.main;
        if (!cam.GetComponent<RotateRoom>().cameraMove)
        {
            SetValue();
            //GameObject.Find("RoomChanger").GetComponent<Scenes>().NextRoom();
            EngineSwipe.SwipeEvent -= cam.GetComponent<RotateRoom>().OnSwipe;
        }
    }

    private void SetValue()
    {
        TempValueCamera.CameraPosition = cam.transform.position;
        TempValueCamera.CameraRotate = cam.transform.eulerAngles;
        TempValueCamera.CurrentAngle = cam.GetComponent<RotateRoom>().currentAngle;
        TempValueCamera.OnSpriteDown = onSpriteDown;
        TempValueCamera.NumWall = GameObject.Find(transform.parent.parent.name).GetComponent<UpWall>().numWall;
    }

    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnMouseDown();
    }
}