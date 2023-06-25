using Unity.VisualScripting;
using UnityEngine;

public static class TempValueCamera
{
    internal static Vector3 CameraPosition { get; set; }
    internal static Vector3 CameraRotate { get; set; }
    internal static int CurrentAngle { get; set; } = 0;
    internal static bool OnSpriteDown { get; set; }
    internal static int NumWall { get; set; }
    internal static string NameRoom { get; set; } = "EntranceRoom";
}
