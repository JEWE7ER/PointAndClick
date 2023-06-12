using UnityEngine;

public class UpAngle : MonoBehaviour
{
    private GameObject CameraLink;
    private Vector3 targetPosition;
    private ChangeAngleRoom ChangeAngleRoomLink;
    private int currentAngle;
    private int oldAngle;
    private bool moveAngle = false;
    private float speed;

    public int numAngle;
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
            if (moveAngle)
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
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
