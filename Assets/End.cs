using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    private Vector3 targetPosition;
    private Vector3 startPosition;
    public Canvas canva;
    public GameObject text1;
    public GameObject text2;
    private bool move = false;
    private int i = 0;
    public int speed;
    public Camera camera;
    private int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        targetPosition = new Vector3(0, -5 , 0);
        startPosition = new Vector3(0, 5, 0);
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
                camera.transform.Rotate(5.0f * Time.deltaTime * startPosition);
                //camera.transform.position = Vector3.MoveTowards(startPosition, targetPosition, speed * Time.deltaTime);
                i++;
            }
            else
            {
                camera.transform.Rotate(5.0f * Time.deltaTime * targetPosition);
                //camera.transform.position = Vector3.MoveTowards(targetPosition, startPosition, speed * Time.deltaTime);
                i++;
            }
            if (i > 19)
            {
                i = 0;
                k++;

            }
            

        }
        if (k == 1)
        {
            canva.gameObject.SetActive(true);
            text1.gameObject.SetActive(true);
        }

        if (k == 13)
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
        }


    }
}
