using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWall : MonoBehaviour
{
    protected GameObject CameraLink;
    Vector3 targetPosition;
    private ChangeAngleRoom ChangeAngleRoomLink;
    protected int currentAngle;
    protected int oldAngle;
    public int numWall;
    public float minY = 2.8f;
    public float maxY = 10.0f;
    protected bool moveWall = false;
    protected float speed;


    // Start is called before the first frame update
    void Start()
    {
        CameraLink = GameObject.Find("Main Camera");
        ChangeAngleRoomLink = CameraLink.GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
        oldAngle = currentAngle;
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeAngleRoomLink.cameraMove)
        {
            currentAngle = ChangeAngleRoomLink.currentAngle;
            speed = ChangeAngleRoomLink.pSpeed / 2;
            UpOrDown();
            if (moveWall)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
                //moveWall = false;
            }
        }
    }

    void UpOrDown()
    {
        if (currentAngle != oldAngle)
        {
            if (((numWall - currentAngle > 1) || ((numWall - currentAngle < 0) && (numWall - currentAngle > -3))) && transform.position.y > maxY - 2)
            {
                targetPosition = new Vector3(transform.position.x, minY, transform.position.z);
                moveWall = true;
            }
            else if (((numWall - currentAngle == 1) || (numWall - currentAngle == 0) || (numWall - currentAngle == -3)) && transform.position.y < minY + 2)
            {
                targetPosition = new Vector3(transform.position.x, maxY, transform.position.z);
                moveWall = true;
            }
            oldAngle = currentAngle;
        }
        
    }
}
