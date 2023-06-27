using System.Diagnostics.Tracing;
using UnityEngine;
using static TempValueCamera;
using static SaveState;
using UnityEngine.EventSystems;

public class ExitDetected : MonoBehaviour
{
    private Camera cam;
    private bool onSpriteDown = false;

    public string NameRoom;
    public int numWall;
    public GameObject saveObject;
    public GameObject gameManager;

    public void OnButtonDown()
    {
        EventSystem.current.SetSelectedGameObject(null);
        cam = Camera.main;
        if (!cam.GetComponent<RotateRoom>().cameraMove)
        {
            //saveObject = GameObject.FindGameObjectWithTag("EntranceRoom");
            SaveState.Save(saveObject);
            SetValue();
            gameManager.GetComponent<GameManager>().Transitions(NameRoom);
            //EngineSwipe.SwipeEvent -= cam.GetComponent<RotateRoom>().OnSwipe;
        }
    }

    private void SetValue()
    {
        TempValueCamera.CameraPosition = cam.transform.position;
        TempValueCamera.CameraRotate = cam.transform.eulerAngles;
        TempValueCamera.CurrentAngle = cam.GetComponent<RotateRoom>().currentAngle;
        TempValueCamera.OnSpriteDown = onSpriteDown;
        TempValueCamera.NumWall = numWall;
        TempValueCamera.NameRoom = NameRoom;
    }

    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnButtonDown();
        onSpriteDown = false;
    }
}
