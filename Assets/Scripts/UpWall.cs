using UnityEngine;

public class UpWall : MonoBehaviour
{
    private GameObject CameraLink;
    private Vector3 targetPosition;
    private ChangeAngleRoom ChangeAngleRoomLink;
    private int currentAngle;
    private int oldAngle;
    private bool moveWall = false;
    private float speed;

    public int numWall;
    public float minY = 2.8f;
    public float maxY = 10.0f;

    void Start()
    {
        CameraLink = GameObject.Find("Main Camera");
        ChangeAngleRoomLink = CameraLink.GetComponent<ChangeAngleRoom>();
        currentAngle = ChangeAngleRoomLink.currentAngle;
        Transform();
    }

    void Update()
    {
        if (ChangeAngleRoomLink.isLerp)
        {
            currentAngle = ChangeAngleRoomLink.currentAngle;
            speed = ChangeAngleRoomLink.pSpeed + 0.5f;
            if (currentAngle != oldAngle)
                UpOrDown();
            if (moveWall)
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void Transform()
    {
        UpOrDown();
        if (moveWall)
        {
            transform.position = targetPosition;
            moveWall = false;
        }
    }

    void UpOrDown()
    {
        if (((numWall - currentAngle > 1) || ((numWall - currentAngle < 0) && (numWall - currentAngle > -3))) && 
            transform.position.y > maxY - 2)
        {
            targetPosition = new Vector3(transform.position.x, minY, transform.position.z);
            moveWall = true;
        }
        else if (((numWall - currentAngle == 1) || (numWall - currentAngle == 0) || (numWall - currentAngle == -3)) && 
            transform.position.y < minY + 2)
        {
            targetPosition = new Vector3(transform.position.x, maxY, transform.position.z);
            moveWall = true;
        }
        oldAngle = currentAngle;
    }
}
