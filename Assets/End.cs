using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    private Vector3 targetPosition;
    private Vector3 startPosition;
    public Canvas canva;
    private bool move = false;
    private int i = 1;
    public int speed;
    public Camera camera;
    private int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(7, 7, -12);
        startPosition = new Vector3(12, 7, -7);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        move = true;

    }
    void FixedUpdate()
    {

        if (move)
        {
            if (i < 10)
            {
                camera.transform.position = Vector3.MoveTowards(startPosition, targetPosition, speed * Time.deltaTime);
                i++;
            }
            else
            {
                camera.transform.position = Vector3.MoveTowards(targetPosition, startPosition, speed * Time.deltaTime);
                i++;
            }
            if (i > 20)
            {
                i = 0;
                k++;

            }
            

        }
        if (k == 2)
        {
            canva.gameObject.SetActive(true);
        }


    }
}
