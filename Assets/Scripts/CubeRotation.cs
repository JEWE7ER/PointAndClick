using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public Manager1 manager;
    private Vector3 rotate = new Vector3(0, 0, -90);
    private bool a = false;
    private int i;
   
    void Start()
    {
       
    }
    void OnMouseDown()
    {
        a = true;
        if (i > 9)
        {
            i = 0;
            
        }
       
    }
    void FixedUpdate()
    {
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
