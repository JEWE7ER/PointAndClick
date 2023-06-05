using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera_2 : MonoBehaviour
{
    Animator animator;
    public GameObject targetObject;
    internal int currentAngle = 1;
    Vector3 targetPosition;
    Quaternion targetRotate;
    public float pSpeed = 10.0f;
    internal bool cameraMove = false;
    public float distView = 7.98f;
    protected bool isLerp = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        var posCam = transform.position;
        if (posCam.x == 8 && posCam.z == 8)
        {
            animator.Play("Camera_2");
            currentAngle = 2;
        }
    }

    void Update()
    {
        //switch (currentAngle)
        //{
        //    case 1:
        //        animator.SetTrigger("1-2");
        //        break;
        //    case 2:
        //        animator.SetTrigger("2-3");
        //        break;
        //    case 3:
        //        animator.SetTrigger("3-4");
        //        break;
        //    case 4:
        //        animator.SetTrigger("4-1");
        //        break;
        //}
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Angle1RightMove();
            currentAngle++;
            if (currentAngle == 5)
            {
                currentAngle = 1;
            }
            cameraMove = true;
            Debug.Log("pos: " + transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Angle2LeftMove();
            currentAngle--;
            if (currentAngle == 0)
            {
                currentAngle = 4;
            }
            cameraMove = true;
            Debug.Log("pos: " + transform.position);
        }
        //if (cameraMove)
        //{
        //    targetObject.transform.position = targetPosition;
        //    //cameraMove = false;
        //}
        else
        {
            cameraMove = false;
        }
    }

    //void LateUpdate()
    //{
    //    if (cameraMove)
    //    {
    //        targetObject.transform.position = targetPosition;
    //        targetObject.transform.Rotate(30, -135, 0);
    //        cameraMove = false;
    //    }
    //}

    void Angle1RightMove()
    {
        animator.SetTrigger("1-2");
        //var position = targetObject.transform.position;
        //targetPosition = new Vector3(position.x, position.y, -position.z);

        //cameraMove = true;
    }
    void Angle2LeftMove()
    {
        animator.SetTrigger("2-1");
    }
}
