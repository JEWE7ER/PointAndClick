using UnityEngine;

public static class TempValueCamera
{
    private static Vector3 cameraPosition;
    private static Vector3 cameraRotate;
    private static int currentAngle;
    public static void SetValue(Vector3 targetPosition, Vector3 targetAngle, int angle)
    {
        cameraPosition = targetPosition;
        cameraRotate = targetAngle;
        currentAngle = angle;
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
}
