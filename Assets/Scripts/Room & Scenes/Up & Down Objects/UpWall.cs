using UnityEngine;

public class UpWall : MonoBehaviour
{
    private Camera cam;
    private Vector3 targetPosition;
    private int currentAngle;
    private int oldAngle;
    private bool moveWall = false;

    public int numWall;
    public float minY = 2.8f;
    public float maxY = 10.0f;

    void Start()
    {
        cam = Camera.main;
        currentAngle = cam.GetComponent<RotateRoom>().currentAngle;
        Transform();
    }

    void FixedUpdate()
    {
        if (cam.GetComponent<RotateRoom>().cameraMove || moveWall)
        {
            currentAngle = cam.GetComponent<RotateRoom>().currentAngle;
            if (currentAngle != oldAngle)
                UpOrDown();

            if (moveWall)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, cam.GetComponent<RotateRoom>().speed * 7.5f * Time.deltaTime);

            if (transform.position == targetPosition)
                moveWall = false;
        }
        else if (cam.GetComponent<RotateRoom>().startMove)
        {
            Start();
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
