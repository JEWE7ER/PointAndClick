using UnityEngine;
using static TempValueCamera;

public class ChangeAngleRoom : MonoBehaviour
{
    internal int currentAngle = 1;
    Vector3 targetPosition;
    public float pSpeed = 10.0f;
    internal bool cameraMove = false;
    public float distView = 7.98f;
    protected bool isLerp = false;
    //private static TempValueCamera _camera;
    private Vector3 targetCamPosition;
    private Vector3 targetCamRotate;

    void Start()
    {
        if (TempValueCamera.GetAngle() != 0)
        {
            currentAngle = TempValueCamera.GetAngle();
            targetCamPosition = TempValueCamera.GetCamPos();
            transform.position = targetCamPosition;
            targetCamRotate = TempValueCamera.GetCamRot();
            transform.eulerAngles = targetCamRotate;
            TempValueCamera.SetValue(new Vector3(), new Vector3(), 0);
        }
    }

    //Update is called once per frame
    void Update()
    {
        DoMove();
    }

    protected void DoMove()
    {
        if (cameraMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, pSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x) >= distView && Mathf.Abs(transform.position.z) >= distView)
            {
                isLerp = false;
                //cameraMove = false;
            }
            else
            {
                isLerp = true;
                if (distView - Mathf.Abs(transform.position.x) <= 1/1e3 && distView - Mathf.Abs(transform.position.z) <= 1 / 1e3)
                {
                    transform.position = targetPosition;
                }
            }
        }
        if (!isLerp)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
                currentAngle--;
                if (currentAngle == 0)
                {
                    currentAngle = 4;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
                currentAngle++;
                if (currentAngle == 5)
                {
                    currentAngle = 1;
                }
            }
        }
    }

    protected void MoveRight()
    {
        if (currentAngle % 2 == 1)
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        }
        else if (currentAngle % 2 == 0)
        {
            targetPosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        cameraMove = true;
    }

    protected void MoveLeft()
    {
        if (currentAngle % 2 == 1)
        {
            targetPosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        else if (currentAngle % 2 == 0)
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        }
        cameraMove = true;
    }
}
