using UnityEngine;

public class UpAngle : MonoBehaviour
{
    private Camera cam;
    private Vector3 targetPosition;
    private int currentAngle;
    private int oldAngle;
    private bool moveAngle = false;

    public int numAngle;
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
        if (cam.GetComponent<RotateRoom>().cameraMove || moveAngle)
        {
            currentAngle = cam.GetComponent<RotateRoom>().currentAngle;
            if (currentAngle != oldAngle)
                UpOrDown();
            if (moveAngle)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, cam.GetComponent<RotateRoom>().speed * 7.5f * Time.deltaTime);

            if (transform.position == targetPosition)
                moveAngle = false;
        }
    }

    void Transform()
    {
        UpOrDown();
        if (moveAngle)
            transform.position = targetPosition;
    }

    void UpOrDown()
    {
        if (numAngle != currentAngle)
        {
            targetPosition = new Vector3(transform.position.x, minY, transform.position.z);
            moveAngle = true;
        }
        else
        {
            targetPosition = new Vector3(transform.position.x, maxY, transform.position.z);
            moveAngle = true;
        }
        oldAngle = currentAngle;
    }
}
