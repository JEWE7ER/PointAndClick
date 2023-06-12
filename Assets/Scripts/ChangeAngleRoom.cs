using UnityEngine;
using System;
using static TempValueCamera;

public class ChangeAngleRoom : MonoBehaviour
{
    internal int currentAngle = 1;
    internal bool isLerp = false;

    private bool startMove = false;
    private bool cameraMove = false;
    private Vector3 targetPosition;
    private Vector3 targetRotate;
    private float difDistX;
    private float difDistZ;

    public float distView = 7.991f;
    public float pSpeed = 7.5f;

    void Start()
    {
        difDistX = (float)Math.Round(Mathf.Abs(distView - Mathf.Abs(transform.position.x)), 3);
        difDistZ = (float)Math.Round(Mathf.Abs(distView - Mathf.Abs(transform.position.z)), 3);
        if (TempValueCamera.GetAngle() != 0)
        {
            currentAngle = TempValueCamera.GetAngle();
            targetRotate = TempValueCamera.GetCamRot();
            transform.eulerAngles = targetRotate;
            MoveToStart();
            startMove = true;
            isLerp = true;
            TempValueCamera.SetValue(Vector3.zero, Vector3.zero, 0, false, 0);
        }
        EngineSwipe.SwipeEvent += OnSwipe;
    }

    void Update()
    {
        if (cameraMove || startMove)
        {
            if (cameraMove)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, pSpeed * Time.deltaTime);
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
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, pSpeed * 2 * Time.deltaTime);
                if (transform.position == targetPosition)
                {
                    startMove = false;
                    isLerp = false;
                }
            }
        }
        if (!isLerp)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                MoveLeft();
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                MoveRight();
        }
    }

    private void MoveToStart()
    {
        targetPosition = TempValueCamera.GetCamPos();
        Vector3 startPosition;
        float distanceForLerp = 4;
        if ((currentAngle == 1 || currentAngle == 4 || TempValueCamera.GetSpriteDown()) &&
            !((currentAngle == 1 || currentAngle == 4) && TempValueCamera.GetSpriteDown()))
            distanceForLerp *= -1;

        if (currentAngle % 2 == 0 && TempValueCamera.GetNumWall() % 2 == 0)
            startPosition = new Vector3(targetPosition.x + distanceForLerp, targetPosition.y, targetPosition.z);
        else
            startPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z + distanceForLerp);

        transform.position = startPosition;
    }

    private void MoveRight()
    {
        if (currentAngle % 2 == 1)
            targetPosition = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        else if (currentAngle % 2 == 0)
            targetPosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);

        currentAngle++;
        if (currentAngle == 5)
            currentAngle = 1;

        cameraMove = true;
    }

    private void MoveLeft()
    {
        if (currentAngle % 2 == 1)
            targetPosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        else if (currentAngle % 2 == 0)
            targetPosition = new Vector3(transform.position.x, transform.position.y, -transform.position.z);

        currentAngle--;
        if (currentAngle == 0)
            currentAngle = 4;

        cameraMove = true;
    }

    internal void OnSwipe(Vector2 direction)
    {
        if (!isLerp)
        {
            if (direction.x > 0)
                MoveLeft();
            else if (direction.x < 0)
                MoveRight();
        }
    }
}
