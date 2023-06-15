using UnityEngine;
using System;
using static TempValueCamera;

public class RotateRoom : MonoBehaviour
{
    internal int currentAngle = 1;
    internal bool cameraMove = false;
    internal bool zoom = false;

    private bool stop = false;
    private bool startMove = false;
    private Vector3 targetPosition;
    [SerializeField()] Vector3 rotation;
    
    public float speed = 2.0f;

    void Start()
    {
        if (TempValueCamera.CurrentAngle != 0)
        {
            currentAngle = TempValueCamera.CurrentAngle;
            transform.eulerAngles = TempValueCamera.CameraRotate;
            MoveToStart();
            startMove = true;
            SetValue();
        }
        else
            targetPosition = transform.position;

        EngineSwipe.SwipeEvent += OnSwipe;
    }
    void FixedUpdate()
    {
        if (cameraMove || startMove)
        {
            if (cameraMove)
            {
                transform.SetPositionAndRotation(Quaternion.Euler(speed * Time.deltaTime * rotation) * transform.position,
                                                 Quaternion.Euler(speed * Time.deltaTime * rotation) * transform.rotation);
                if (Mathf.Abs(transform.position.x) > Mathf.Abs(targetPosition.x) || 
                    Mathf.Abs(transform.position.z) > Mathf.Abs(targetPosition.z))
                    stop = true;

                if (Math.Round(MathF.Abs(transform.position.x)) == Math.Round(MathF.Abs(transform.position.z)) && stop)
                {
                    transform.position = targetPosition;
                    cameraMove = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * 7.5f * Time.deltaTime);
                if (transform.position == targetPosition)
                    startMove = false;
            }
        }
    }

    void Update()
    {
        if (!cameraMove && !startMove && !zoom)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                MoveLeft();
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                MoveRight();
        }
    }

    private void MoveToStart()
    {
        targetPosition = TempValueCamera.CameraPosition;
        Vector3 startPosition;
        float distanceForMove = 4;
        if ((currentAngle == 1 || currentAngle == 4 || TempValueCamera.OnSpriteDown) &&
            !((currentAngle == 1 || currentAngle == 4) && TempValueCamera.OnSpriteDown))
            distanceForMove *= -1;

        if (currentAngle % 2 == 0 && TempValueCamera.NumWall % 2 == 0)
            startPosition = new Vector3(targetPosition.x + distanceForMove, targetPosition.y, targetPosition.z);
        else
            startPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z + distanceForMove);

        transform.position = startPosition;
    }

    private void MoveRight()
    {
        if (rotation.y > 0)
            rotation.y *= -1;

        if (currentAngle % 2 == 1)
            targetPosition.z *= -1;
        else if (currentAngle % 2 == 0)
            targetPosition.x *= -1;

        currentAngle++;
        if (currentAngle == 5)
            currentAngle = 1;

        cameraMove = true;
    }

    private void MoveLeft()
    {
        if (rotation.y < 0)
            rotation.y *= -1;

        if (currentAngle % 2 == 1)
            targetPosition.x *= -1;
        else if (currentAngle % 2 == 0)
            targetPosition.z *= -1;

        currentAngle--;
        if (currentAngle == 0)
            currentAngle = 4;

        cameraMove = true;
    }

    internal void OnSwipe(Vector2 direction)
    {
        if (!cameraMove && !startMove && !zoom)
        {
            if (direction.x > 0)
                MoveLeft();
            else if (direction.x < 0)
                MoveRight();
        }
    }

    private void SetValue()
    {
        TempValueCamera.CameraPosition = Vector3.zero;
        TempValueCamera.CameraRotate = Vector3.zero;
        TempValueCamera.CurrentAngle = 0;
        TempValueCamera.OnSpriteDown = false;
        TempValueCamera.NumWall = 0;
    }
}
