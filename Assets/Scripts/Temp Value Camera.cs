using Unity.VisualScripting;
using UnityEngine;

public static class TempValueCamera
{
    private static Vector3 _cameraPosition;
    private static Vector3 _cameraRotate;
    private static int _currentAngle;
    private static bool _onSpriteDown;
    private static int _numWall;

    public static void SetValue(Vector3 cameraPosition, Vector3 cameraRotate, 
        int currentAngle, bool onSpriteDown, int numWall)
    {
        _cameraPosition = cameraPosition;
        _cameraRotate = cameraRotate;
        _currentAngle = currentAngle;
        _onSpriteDown = onSpriteDown;
        _numWall = numWall;
    }

    public static int GetAngle()
    {
        return _currentAngle;
    }

    public static int GetNumWall()
    {
        return _numWall;
    }

    public static Vector3 GetCamPos()
    {
        return _cameraPosition;
    }
    public static Vector3 GetCamRot()
    {
        return _cameraRotate;
    }
    public static bool GetSpriteDown()
    {
        return _onSpriteDown;
    }
}
