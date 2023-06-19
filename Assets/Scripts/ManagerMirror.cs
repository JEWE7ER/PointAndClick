using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerMirror : MonoBehaviour
{
    public MirrorRotate[] mirror;
    private bool isWin = false;
    //Vector3(330,0,90) Vector3(330,0,90)
    //Vector3(340.000031,180,270) Vector3(330.000031,180,270)
    //Vector3(330,0,90) Vector3(330,0,90)
    public void win()
    {
        //&& Math.Round(mirror[1].transform.localEulerAngles.x) == 330 
        // && Math.Round(mirror[3].transform.localEulerAngles.z) == 330

        for (int i = 0; i < mirror.Length-1; i++)
        {

            if (Math.Round(mirror[i].transform.localEulerAngles.x) == 350 || i == 1  && Math.Round(mirror[i].transform.localEulerAngles.x) == 10)
            {

            }
            else

            {
                return;
            }

        }
        isWin = true;



    }
    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            
            mirror[3].transform.position = Vector3.Lerp(mirror[3].transform.position, new Vector3((float)-4.80585098, (float)1.19000006, (float)-2.07143688), Time.deltaTime * 0.8f);
        }
    }
}
