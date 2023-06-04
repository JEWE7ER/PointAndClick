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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Angle1RightMove();
            currentAngle++;
            if (currentAngle == 5)
            {
                currentAngle = 1;
            }
        }
        //if (cameraMove)
        //{
        //    targetObject.transform.position = targetPosition;
        //    //cameraMove = false;
        //}
    }

    void LateUpdate()
    {
        if (cameraMove)
        {
            targetObject.transform.position = targetPosition;
            targetObject.transform.Rotate(30,-135,0);
            //cameraMove = false;
        }
    }

    void Angle1RightMove()
    {
        animator.SetTrigger("Play");
        var position = targetObject.transform.position;
        targetPosition = new Vector3(position.x, position.y, -position.z);

        cameraMove = true;
    }
}
