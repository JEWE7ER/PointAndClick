using UnityEngine;
using static TempValueCamera;

public class ExitNextDetected : MonoBehaviour
{
    private GameObject CameraLink;
    private int currentAngle = 0;
    private ChangeAngleRoom ChangeAngleRoomLink;
    protected GameObject ScenesLink;
    private Scenes scene;
    private void OnMouseDown()
    {
        CameraLink = GameObject.Find("Main Camera");
        ChangeAngleRoomLink = CameraLink.GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
        TempValueCamera.SetValue(CameraLink.transform.position, CameraLink.transform.eulerAngles,currentAngle);

        ScenesLink = GameObject.Find("RoomChanger");
        scene = ScenesLink.GetComponent<Scenes>();
        scene.NextRoom();
    }
}
