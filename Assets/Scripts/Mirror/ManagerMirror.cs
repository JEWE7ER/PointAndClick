using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerMirror : MonoBehaviour
{
    public MirrorRotate[] mirror;
    public bool isWin = false;
    public void Win()
    {
        //&& Math.Round(mirror[1].transform.localEulerAngles.x) == 330 
        // && Math.Round(mirror[3].transform.localEulerAngles.z) == 330

        for (int i = 0; i < mirror.Length-1; i++)
            if (!(Math.Round(mirror[i].transform.localEulerAngles.x / 10) * 10 == 350 || 
                i == 1  && Math.Round(mirror[i].transform.localEulerAngles.x / 10) * 10 == 10))
                return;
        isWin = true;
    }

    //void Update()
    //{
    //    if (isWin)
    //        mirror[3].transform.position = Vector3.Lerp(mirror[3].transform.position, 
    //            new Vector3((float)-4.80585098, (float)1.19000006, (float)-2.07143688), Time.deltaTime * 0.8f);
    //}
}
