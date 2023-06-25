using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotate : MonoBehaviour
{
    public ManagerMirror manager;
    private Vector3 rotate = new Vector3(0, -10, 0);
    private bool a = false;

    private int i;
    //Vector3(330,0,90) Vector3(330,0,90)
    //Vector3(340.000031,180,270) Vector3(330.000031,180,270)
    //Vector3(330,0,90) Vector3(330,0,90)
    void Start()
    {

    }
    void OnMouseDown()
    {
        a = true;
        if (i > 8)
        {
            i = 0;

        }
    }
    void FixedUpdate()
    {
        


        if (transform.localEulerAngles.x >= 20 && transform.localEulerAngles.x < 100) 
        {
            rotate = new Vector3(0, 10, 0);
        }
        if (transform.localEulerAngles.x <= 290 && transform.localEulerAngles.x > 250)
        {
            rotate = new Vector3(0, -10, 0);
        }
        if (a)
        {
            transform.Rotate(rotate * Time.deltaTime * 5.0f);
            if (i >= 9)
            {
                a = false;
            }
            i += 1;
            manager.win();

        }
    }
}
