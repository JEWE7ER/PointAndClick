using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngleRoom : MonoBehaviour
{
    public GameObject targetObject;

    internal int currentAngle = 1;
    Vector3 targetPosition;
    public float pSpeed = 10.0f;
    internal bool camera_move_enabled = false;
    public float distView = 7.98f;
    protected bool isLerp = false;

    //Update is called once per frame
    void Update()
    {
        DoMove();
    }

    protected void DoMove()
    {
        if (camera_move_enabled)
        {
            targetObject.transform.position = Vector3.Lerp(transform.position, targetPosition, pSpeed * Time.deltaTime);
            if (Mathf.Abs(targetObject.transform.position.x) >= distView && Mathf.Abs(targetObject.transform.position.z) >= distView)
            {
                isLerp = false;
            }
            else
            {
                isLerp = true;
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
        var coord = targetObject.transform.position;
        if (currentAngle % 2 == 1)
        {
            targetPosition = new Vector3(coord.x, coord.y, -coord.z);
        }
        else if (currentAngle % 2 == 0)
        {
            targetPosition = new Vector3(-coord.x, coord.y, coord.z);
        }
        camera_move_enabled = true;
    }

    protected void MoveLeft()
    {
        var coord = targetObject.transform.position;
        if (currentAngle % 2 == 1)
        {
            targetPosition = new Vector3(-coord.x, coord.y, coord.z);
        }
        else if (currentAngle % 2 == 0)
        {
            targetPosition = new Vector3(coord.x, coord.y, -coord.z);
        }
        camera_move_enabled = true;
    }
}
