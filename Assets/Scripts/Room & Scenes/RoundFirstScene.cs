using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundFirstScene : MonoBehaviour
{
    private float BorderRight;
    private float BorderLeft;
    private Vector3 rotation;

    public float yRotate;
    public float speed;

    void Start()
    {
        BorderRight = transform.eulerAngles.y;
        BorderLeft = transform.eulerAngles.y + yRotate;
        rotation = new Vector3(0, transform.eulerAngles.y + yRotate, 0);
    }

    void FixedUpdate()
    {
        transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, rotation, speed * Time.deltaTime);
        if (transform.eulerAngles.y <= BorderLeft || transform.eulerAngles.y >= BorderRight)
        {
            yRotate *= -1;
            rotation.y = transform.eulerAngles.y + yRotate;
        }
    }
}
