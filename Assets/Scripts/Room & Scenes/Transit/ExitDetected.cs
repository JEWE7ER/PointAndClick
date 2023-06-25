using System.Diagnostics.Tracing;
using UnityEngine;
using static TempValueCamera;
using static SaveState;

public class ExitDetected : MonoBehaviour
{
    private Camera cam;
    private bool onSpriteDown = false;

    public string Name;
    public GameObject saveObject;

    public void OnButtonDown()
    {
        cam = Camera.main;
        if (!cam.GetComponent<RotateRoom>().cameraMove)
        {
            //saveObject = GameObject.FindGameObjectWithTag("EntranceRoom");
            SaveState.Save(saveObject);
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
        OnButtonDown();
    }
}
