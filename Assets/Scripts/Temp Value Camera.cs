using Unity.VisualScripting;
using UnityEngine;

public static class TempValueCamera
{
    private static Vector3 cameraPosition;
    private static Vector3 cameraRotate;
    private static int currentAngle;
    private static bool onSpriteDown;
    public static void SetValue(Vector3 targetPosition, Vector3 targetAngle, int angle, bool onSprite)
    {
        cameraPosition = targetPosition;
        cameraRotate = targetAngle;
        currentAngle = angle;
        onSpriteDown = onSprite;
    }

    public static int GetAngle()
    {
        return currentAngle;
    }

    public static Vector3 GetCamPos()
    {
        return cameraPosition;
    }
    public static Vector3 GetCamRot()
    {
        return cameraRotate;
    }
    public static bool GetSpriteDown()
    {
        return onSpriteDown;
    }
}
