using UnityEngine;

public class UpAngle : MonoBehaviour
{
    protected GameObject CameraLink;
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
            if (moveAngle)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

    void UpOrDown()
    {
        if (currentAngle != oldAngle)
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
}
