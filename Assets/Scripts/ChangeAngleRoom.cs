using UnityEngine;

public class ChangeAngleRoom : MonoBehaviour
{
    internal int currentAngle = 1;
    Vector3 targetPosition;
    public float pSpeed = 10.0f;
    internal bool cameraMove = false;
    public float distView = 7.98f;
    protected bool isLerp = false;

    //void Start()
    //{
    //}

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
