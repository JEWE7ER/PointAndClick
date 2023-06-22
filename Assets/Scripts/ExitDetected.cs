using UnityEngine;
using static TempValueCamera;

public class ExitDetected : MonoBehaviour
{
    private GameObject CameraLink;
    private ChangeAngleRoom ChangeAngleRoomLink;
    private int currentAngle = 0;
    private GameObject ScenesLink;
    private Scenes scene;
    private GameObject WallLink;
    private UpWall wall;
    private bool onSpriteDown = false;

    public string Name;

    private void OnMouseDown()
    {
        WallLink = GameObject.Find(transform.parent.parent.name);
        wall = WallLink.GetComponent<UpWall>();
        CameraLink = GameObject.Find("Main Camera");
        ChangeAngleRoomLink = CameraLink.GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
        if (!ChangeAngleRoomLink.isLerp)
        {
<<<<<<< Updated upstream:Assets/Scripts/ExitNextDetected.cs
            TempValueCamera.SetValue(CameraLink.transform.position, CameraLink.transform.eulerAngles, 
                currentAngle, onSpriteDown, wall.numWall);
            ScenesLink = GameObject.Find("RoomChanger");
            scene = ScenesLink.GetComponent<Scenes>();
            scene.NextRoom();
            EngineSwipe.SwipeEvent -= ChangeAngleRoomLink.OnSwipe;
=======
            SetValue();
            GameObject.Find("RoomChanger").GetComponent<Scenes>().LoadRoom(Name);
            EngineSwipe.SwipeEvent -= cam.GetComponent<RotateRoom>().OnSwipe;
>>>>>>> Stashed changes:Assets/Scripts/ExitDetected.cs
        }
    }
    public void OnSpriteDown()
    {
        onSpriteDown = true;
        OnMouseDown();
        //onSpriteDown = false;
    }

}
