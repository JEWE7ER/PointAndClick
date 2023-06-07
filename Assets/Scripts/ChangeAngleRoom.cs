using UnityEngine;
using System;
using static TempValueCamera;

public class ChangeAngleRoom : MonoBehaviour
{
    internal int currentAngle = 1;
    Vector3 targetPosition;
    public float pSpeed = 7.5f;
    private bool startMove = false;
    internal bool cameraMove = false;
    public float distView = 7.991f;
    protected bool isLerp = false;
    private Vector3 targetRotate;
    private float difDistX = 0;
    private float difDistZ = 0;

    void Start()
    {
        difDistX = (float)Math.Round(Mathf.Abs(distView - Mathf.Abs(transform.position.x)), 3);
        difDistZ = (float)Math.Round(Mathf.Abs(distView - Mathf.Abs(transform.position.z)), 3);
        if (TempValueCamera.GetAngle() != 0)
        {
            currentAngle = TempValueCamera.GetAngle();
            targetRotate = TempValueCamera.GetCamRot();
            transform.eulerAngles = targetRotate;
            //pSpeed /= 2;
            LerpToStart();
            startMove = true;
            TempValueCamera.SetValue(new Vector3(), new Vector3(), 0, false);
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (cameraMove || startMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, pSpeed * Time.deltaTime);
            if (startMove)
            {
                startMove = false;
                cameraMove = true;
                //pSpeed *= 2;
            }
            //if (Mathf.Abs(transform.position.x) >= distView && Mathf.Abs(transform.position.z) >= distView)
            //{
            //    isLerp = false;
            //    cameraMove = false;
            //}
            if (Mathf.Abs(distView - Mathf.Abs(transform.position.x)) <= difDistX + 1 / 1e4 &&
                Mathf.Abs(distView - Mathf.Abs(transform.position.z)) <= difDistZ + 1 / 1e4)
            {
                transform.position = targetPosition;
                isLerp = false;
                cameraMove = false;
            }
            else
            {
                isLerp = true;
                //if (distView - Mathf.Abs(transform.position.x) <= 9 / 1e2 && distView - Mathf.Abs(transform.position.z) <= 9 / 1e2)
                //{
                //    transform.position = targetPosition;
                //}
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

    protected void LerpToStart()
    {
        targetPosition = TempValueCamera.GetCamPos();
        Vector3 startPosition;
        float distanceForLerp = 8;
        if (currentAngle == 1 || currentAngle == 4 || TempValueCamera.GetSpriteDown())
        {
            distanceForLerp *= -1;
        }
        if (currentAngle % 2 == 0)
        {
            startPosition = new Vector3(targetPosition.x + distanceForLerp, targetPosition.y, targetPosition.z);
        }
        else
        {
            startPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z + distanceForLerp);
        }
        //transform.position = Vector3.Lerp(startPosition, targetPosition, pSpeed/2 * Time.deltaTime);
        transform.position = startPosition;
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
