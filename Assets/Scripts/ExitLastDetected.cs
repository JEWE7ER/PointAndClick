using UnityEngine;
using static TempValueCamera;

public class ExitLastDetected : MonoBehaviour
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
        if (!ChangeAngleRoomLink.cameraMove)
        {
            currentAngle = ChangeAngleRoomLink.currentAngle;
            TempValueCamera.SetValue(CameraLink.transform.position, CameraLink.transform.eulerAngles, currentAngle, onSpriteDown);
            ScenesLink = GameObject.Find("RoomChanger");
            scene = ScenesLink.GetComponent<Scenes>();
            scene.PrevRoom();
        }
    }
    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnMouseDown();
        onSpriteDown = false;
    }
}
