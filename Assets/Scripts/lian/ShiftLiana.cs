using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftLiana : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(0, 0, -90);
    public int id;
    public int speed =10;

    void Start()
    {
        if (id == 1)
        {
            targetPosition = new Vector3(transform.position.x - (float)0.3, transform.position.y, transform.position.z);
        }
        else if (id == 2)
        {
            targetPosition = new Vector3(transform.position.x + (float)0.3, transform.position.y , transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(transform.position.x , transform.position.y, transform.position.z - (float)0.3);
        }
    }

    void OnMouseDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
