using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotate : MonoBehaviour
{
    private Vector3 rotate = new Vector3(0, -10, 0);
    private bool move = false;
    private int countRotation;

    public ManagerMirror mirrorManager;
    //Vector3(330,0,90) Vector3(330,0,90)
    //Vector3(340.000031,180,270) Vector3(330.000031,180,270)
    //Vector3(330,0,90) Vector3(330,0,90)

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
        if (move)
        {
            transform.Rotate(5.0f * Time.deltaTime * rotate);
            if (countRotation >= 9)
            {
                move = false;
            }
            countRotation += 1;
            mirrorManager.Win();

        }
    }
    void OnMouseDown()
    {
        if (!mirrorManager.isWin && !move)
        {
            move = true;
            if (countRotation > 8)
                countRotation = 0;
        }
    }
}
