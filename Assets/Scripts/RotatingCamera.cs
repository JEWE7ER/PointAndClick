using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    private ChangeAngleRoom ChangeAngleRoomLink;
    private float targetAngle = 0;
    private const float rotationAmount = 1.5f;
    private int currentAngle;

    void Start()
    {
        ChangeAngleRoomLink = GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
    }

    //Update is called once per frame
    void Update()
    {
        if (ChangeAngleRoomLink.isLerp)
        {
            if ((currentAngle - ChangeAngleRoomLink.currentAngle > 0 && currentAngle - ChangeAngleRoomLink.currentAngle != 3) ||
               currentAngle - ChangeAngleRoomLink.currentAngle == -3)
                targetAngle -= 90.0f;
            else if (currentAngle - ChangeAngleRoomLink.currentAngle < 0 || currentAngle - ChangeAngleRoomLink.currentAngle == 3)
                targetAngle += 90.0f;
            if (targetAngle != 0)
            {
                Rotate();
                currentAngle = ChangeAngleRoomLink.currentAngle;
            }
        }
    }

    protected void Rotate()
    {
        if (targetAngle > 0)
        {
            transform.RotateAround(transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }
    }
}
