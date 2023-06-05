using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    private ChangeAngleRoom ChangeAngleRoomLink;
    private float targetAngle = 0;
    const float rotationAmount = 1.5f;
    public float rDistance = 1.0f;
    public float rSpeed = 1.0f;

    protected int currentAngle;

    void Start()
    {
        ChangeAngleRoomLink = GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
    }

    //Update is called once per frame
    void Update()
    {
        if ((currentAngle - ChangeAngleRoomLink.currentAngle > 0 && currentAngle - ChangeAngleRoomLink.currentAngle != 3) 
            || currentAngle - ChangeAngleRoomLink.currentAngle == -3)
        {
            targetAngle -= 90.0f;
        }
        else if (currentAngle - ChangeAngleRoomLink.currentAngle < 0 || currentAngle - ChangeAngleRoomLink.currentAngle == 3)
        {
            targetAngle += 90.0f;
        }

        if (targetAngle != 0)
        {
            Rotate();
            currentAngle = ChangeAngleRoomLink.currentAngle;
        }
    }

    protected void Rotate()
    {

        //float step = rSpeed * Time.deltaTime;
        //float orbitCircumfrance = 2F * rDistance * Mathf.PI;
        //float distanceDegrees = (rSpeed / orbitCircumfrance) * 360;
        //float distanceRadians = (rSpeed / orbitCircumfrance) * 2 * Mathf.PI;

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
