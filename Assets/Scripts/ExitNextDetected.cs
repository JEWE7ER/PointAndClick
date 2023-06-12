using UnityEngine;
using static TempValueCamera;

public class ExitNextDetected : MonoBehaviour
{
    private GameObject CameraLink;
    private ChangeAngleRoom ChangeAngleRoomLink;
    private int currentAngle = 0;
    private GameObject ScenesLink;
    private Scenes scene;
    private GameObject WallLink;
    private UpWall wall;
    private bool onSpriteDown = false;

    private void OnMouseDown()
    {
        WallLink = GameObject.Find(transform.parent.parent.name);
        wall = WallLink.GetComponent<UpWall>();
        CameraLink = GameObject.Find("Main Camera");
        ChangeAngleRoomLink = CameraLink.GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
        if (!ChangeAngleRoomLink.isLerp)
        {
            TempValueCamera.SetValue(CameraLink.transform.position, CameraLink.transform.eulerAngles, 
                currentAngle, onSpriteDown, wall.numWall);
            ScenesLink = GameObject.Find("RoomChanger");
            scene = ScenesLink.GetComponent<Scenes>();
            scene.NextRoom();
            EngineSwipe.SwipeEvent -= ChangeAngleRoomLink.OnSwipe;
        }
    }
    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnMouseDown();
        //onSpriteDown = false;
    }

}
