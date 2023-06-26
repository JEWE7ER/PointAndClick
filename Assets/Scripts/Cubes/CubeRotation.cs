using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private Vector3 rotate = new Vector3(0, 0, -90);
    private bool move = false;
    private int countRotation;

    public CubeManager cubeManager;


    void OnMouseDown()
    {
        if (!cubeManager.isWin && !move)
        {
            move = true;
            if (countRotation > 9)
                countRotation = 0;
        }
       
    }
    void FixedUpdate()
    {
        if (move)
        {
            transform.Rotate(5.0f * Time.deltaTime * rotate);
            if (countRotation >= 9)
                move = false;

            countRotation += 1;
            cubeManager.Win();
            
        }

    }
}
