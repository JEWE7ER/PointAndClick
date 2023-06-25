using UnityEngine;
using System;
using static TempValueCamera;
using UnityEngine.SceneManagement;
using TMPro;

public class RotateRoom : MonoBehaviour
{
    internal int currentAngle = 1;
    internal bool cameraMove = false;
    internal bool startMove = false;
    internal bool zoom = false;

    private bool stop = false;
    private Vector3 targetPosition;
    private readonly string RoomWithBorders = "EntranceRoom";
    private bool BorderedRoom;
    private bool fakeMove = false;
    private bool fakeMoveFwd = false;
    private bool fakeMoveBck = false;
    private Vector3 tempPosition;

    [SerializeField()] Vector3 rotation;
    public float speed = 2.0f;

    void Start()
    {
        targetPosition = transform.position;
        EngineSwipe.SwipeEvent += OnSwipe;
    }

    void FixedUpdate()
    {
        if (cameraMove || startMove || fakeMove)
        {
            if (cameraMove || fakeMove)
            {
                transform.SetPositionAndRotation(Quaternion.Euler(speed * Time.deltaTime * rotation) * transform.position,
                                                 Quaternion.Euler(speed * Time.deltaTime * rotation) * transform.rotation);

                if (cameraMove)
                {
                    if (Mathf.Abs(transform.position.x) > Mathf.Abs(targetPosition.x) ||
                        Mathf.Abs(transform.position.z) > Mathf.Abs(targetPosition.z))
                        stop = true;

                    if (Math.Round(MathF.Abs(transform.position.x)) == Math.Round(MathF.Abs(transform.position.z)) && stop)
                    {
                        transform.position = targetPosition;
                        cameraMove = false;
                        stop = false;
                    }
                }
                else
                {
                    if (fakeMoveFwd)
                    {
                        if (transform.position.z >= targetPosition.z)
                            stop = true;

                        if (stop)
                        {
                            fakeMoveFwd = false;
                            FakeMoveBck();
                            stop = false;
                        }
                    }
                    else if (fakeMoveBck)
                    {
                        if (transform.position.z <= targetPosition.z)
                            stop = true;

                        if (stop)
                        {
                            transform.position = targetPosition;
                            fakeMoveBck = false;
                            fakeMove = false;
                            stop = false;
                            //rotation.y *= -1;
                            speed *= 2;
                        }
                            
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * 7.5f * Time.deltaTime);
                if (transform.position == targetPosition)
                    startMove = false;
            }
        }
        if (TempValueCamera.CurrentAngle != 0)
            ReloadPosition();
    }

    void Update()
    {
        if (!cameraMove && !startMove && !zoom && !fakeMove)
        {
            bool leftBorder = BorderedRoom && currentAngle == 4;
            bool rightBorder = BorderedRoom && currentAngle == 1;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!leftBorder)
                    MoveLeft();
                else
                    FakeMoveLeftFwd();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!rightBorder)
                    MoveRight();
                else
                    FakeMoveRightFwd();
            }
        }
    }

    private void MoveToStart()
    {
        Vector3 startPosition;
        float distanceForMove = 6;
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

    private void FakeMoveLeftFwd()
    {
        if (rotation.y < 0)
            rotation.y *= -1;

        FakeMove();
    }
   
    private void FakeMoveRightFwd()
    {
        if (rotation.y > 0)
            rotation.y *= -1;

        FakeMove();
    }

    private void FakeMove()
    {
        fakeMove = true;
        fakeMoveFwd = true;
        tempPosition = targetPosition;
        targetPosition.z /= 8.0f;
        speed /= 2;
    }

    private void FakeMoveBck()
    {
        targetPosition.z = tempPosition.z;
        fakeMoveBck = true;
        rotation.y *= -1;
    }

    internal void OnSwipe(Vector2 direction)
    {
        if (!cameraMove && !startMove && !zoom && !fakeMove)
        {
            bool leftBorder = BorderedRoom && currentAngle == 4;
            bool rightBorder = BorderedRoom && currentAngle == 1;
            if (direction.x > 0)
            {
                if (!leftBorder)
                    MoveLeft();
                else
                    FakeMoveLeftFwd();
            }
            else if (direction.x < 0)
            {
                if (!rightBorder)
                    MoveRight(); 
                else
                    FakeMoveRightFwd();
            }
        }
    }

    private void ReloadPosition()
    {
        BorderedRoom = TempValueCamera.NameRoom.Equals(RoomWithBorders);
        currentAngle = TempValueCamera.CurrentAngle;
        if (!BorderedRoom || (BorderedRoom && currentAngle == 4))
        {
            transform.eulerAngles = TempValueCamera.CameraRotate;
            SetTargetPosition();//targetPosition = TempValueCamera.CameraPosition;
        }
        else if (currentAngle != 1)
        {
            if (currentAngle == 3)
            {
                transform.eulerAngles = new Vector3(25, 45, 0);
                currentAngle = 4;
            }
            else if (currentAngle == 2)
            {
                transform.eulerAngles = new Vector3(25, -45, 0);
                currentAngle = 1;
            }
            targetPosition.z *= -1;
            transform.position = targetPosition;
        }
        MoveToStart();
        startMove = true;
        SetValue();
    }

    private void SetValue()
    {
        TempValueCamera.CameraPosition = Vector3.zero;
        TempValueCamera.CameraRotate = Vector3.zero;
        TempValueCamera.CurrentAngle = 0;
        TempValueCamera.OnSpriteDown = false;
        TempValueCamera.NumWall = 0;
    }

    private void SetTargetPosition()
    {
        Vector3 tempPosition = TempValueCamera.CameraPosition;
        if ((transform.position.x < 0 && tempPosition.x > 0) || 
            (transform.position.x > 0 && tempPosition.x < 0))
            targetPosition.x *= -1;
        if ((transform.position.z < 0 && tempPosition.z > 0) ||
            (transform.position.z > 0 && tempPosition.z < 0))
            targetPosition.z *= -1;
    }
}
