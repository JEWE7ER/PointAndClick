using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWall : MonoBehaviour
{
    protected GameObject CameraLink;
    public GameObject targetObject;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeAngleRoomLink.camera_move_enabled)
        {
            currentAngle = ChangeAngleRoomLink.currentAngle;
            speed = ChangeAngleRoomLink.pSpeed / 2;
            UpOrDown();
            if (moveWall)
            {
                targetObject.transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        //Debug.Log("Current Angle wawll:" + ChangeAngleRoomLink.currentAngle);
    }

    void UpOrDown()
    {
        if (currentAngle != oldAngle)
        {
            if (((numWall - currentAngle > 1) || ((numWall - currentAngle < 0) && (numWall - currentAngle > -3))) && targetObject.transform.position.y > 8)
            {
                var coord = targetObject.transform.position;
                targetPosition = new Vector3(coord.x, minY, coord.z);
                moveWall = true;
                //Debug.Log("Current numWall:" + numWall);
            }
            else if (((numWall - currentAngle == 1) || (numWall - currentAngle == 0) || (numWall - currentAngle == -3)) && targetObject.transform.position.y < 4)
            {
                var coord = targetObject.transform.position;
                targetPosition = new Vector3(coord.x, maxY, coord.z);
                moveWall = true;
            }
            //Debug.Log("Current Angle wall:" + ChangeAngleRoomLink.currentAngle);
            oldAngle = currentAngle;

        }
        
    }
}
