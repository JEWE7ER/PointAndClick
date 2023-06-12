using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZoomObjects : MonoBehaviour
{
    private Camera cam;
    private static Vector3 DefaultPositionCamera;
    private static Vector3 DefaultRotateCamera;
    private Vector3 PositionPoint;
    private Vector3 RotatePoint;
    private bool moveToPoint = false;
    private bool moveToDefault = false;
    private float fullLen;
    private float boost = 6;
    private bool isBoost = false;
    private float rSpeed;
    private float coefLen;
    //private static Button hideButton;

    public Canvas hideCanvas;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    public float speed;

    void Start()
    {
        cam = Camera.main;
        //hideButton = button;
        hideCanvas.enabled = false;
        rSpeed = speed;
        //coefLen = 2.0f/3.0f;
        //PositionPoint = new Vector3(positionX, positionY, positionZ);
    }

    private void Update()
    {
        if (moveToPoint)
            MoveCamera(ref moveToPoint, PositionPoint, RotatePoint);

        else if (moveToDefault)
        {
            MoveCamera(ref moveToDefault, DefaultPositionCamera, DefaultRotateCamera);
            if (!moveToDefault)
                cam.GetComponent<ChangeAngleRoom>().isLerp = false;

        }
    }
    private void OnMouseDown()
    {
        if (!moveToPoint && cam.transform.position != PositionPoint)
        {
            DefaultPositionCamera = cam.transform.position;
            DefaultRotateCamera = cam.transform.eulerAngles;
            moveToPoint = true;
            hideCanvas.enabled = true;
            PositionPoint = new Vector3(positionX, positionY, positionZ);
            RotatePoint = new Vector3(rotateX, rotateY, rotateZ);
            FullLength(DefaultPositionCamera, PositionPoint);
            coefLen = 1.0f / 3.0f;

            cam.GetComponent<ChangeAngleRoom>().isLerp = true;
        }
    }

    public void TapOnButton()
    {
        moveToDefault = true;
        hideCanvas.enabled = false;
        coefLen = 3.0f / 4.0f;
        //FullLength(PositionPoint, DefaultPositionCamera);
    }

    private void FullLength(Vector3 startPosition, Vector3 targetPosition)
    {
        fullLen = Mathf.Sqrt(Mathf.Pow(startPosition.x - targetPosition.x, 2) + Mathf.Pow(startPosition.y - targetPosition.y, 2) +
                             Mathf.Pow(startPosition.z - targetPosition.z, 2));
    }

    private void MoveCamera(ref bool move, Vector3 targetPosition, Vector3 targetRotate)
    {
        float len = Mathf.Sqrt(Mathf.Pow(cam.transform.position.x - targetPosition.x, 2) + Mathf.Pow(cam.transform.position.y - targetPosition.y, 2) +
                               Mathf.Pow(cam.transform.position.z - targetPosition.z, 2));
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, targetPosition, speed * Time.deltaTime);
        if (len < fullLen * coefLen && cam.transform.eulerAngles != targetRotate && !isBoost)
        {
            speed /= 2;
            boost += 4;
            isBoost = true;
        }

        cam.transform.eulerAngles = Vector3.MoveTowards(cam.transform.eulerAngles, targetRotate, rSpeed * boost * Time.deltaTime);
        if (cam.transform.position == targetPosition && cam.transform.eulerAngles == targetRotate)
        {
            move = false;
            if (isBoost)
            {
                speed *= 2;
                boost -= 4;
                isBoost = false;
            }
        }
    }
}
