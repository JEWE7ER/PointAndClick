using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAngle : MonoBehaviour
{
    protected GameObject CameraLink;
    public GameObject targetObject;
    Vector3 targetPosition;
    private ChangeAngleRoom ChangeAngleRoomLink;
    protected int currentAngle;
    protected int oldAngle;
    public int numAngle;
    public float minY = 2.8f;
    public float maxY = 10.0f;
    protected bool moveAngle = false;
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
            if (moveAngle)
            {
                targetObject.transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

    void UpOrDown()
    {
        if (currentAngle != oldAngle)
        {
            if (numAngle != currentAngle)
            {
                var coord = targetObject.transform.position;
                targetPosition = new Vector3(coord.x, minY, coord.z);
                moveAngle = true;
            }
            else
            {
                var coord = targetObject.transform.position;
                targetPosition = new Vector3(coord.x, maxY, coord.z);
                moveAngle = true;
            }
            oldAngle = currentAngle;

        }

    }
}
