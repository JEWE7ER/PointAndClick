using UnityEngine;
using static TempValueCamera;

public class ExitNextDetected : MonoBehaviour
{
    private GameObject CameraLink;
    private int currentAngle = 0;
    private ChangeAngleRoom ChangeAngleRoomLink;
    protected GameObject ScenesLink;
    private Scenes scene;
    private bool onSpriteDown = false;
    private void OnMouseDown()
    {
        CameraLink = GameObject.Find("Main Camera");
        ChangeAngleRoomLink = CameraLink.GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
        if (!ChangeAngleRoomLink.cameraMove)
        {
            TempValueCamera.SetValue(CameraLink.transform.position, CameraLink.transform.eulerAngles, currentAngle, onSpriteDown);
            ScenesLink = GameObject.Find("RoomChanger");
            scene = ScenesLink.GetComponent<Scenes>();
            scene.NextRoom();
        }
    }
    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnMouseDown();
        onSpriteDown = false;
    }

}
