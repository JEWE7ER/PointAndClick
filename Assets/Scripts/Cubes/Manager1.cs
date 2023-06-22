using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Manager1 : MonoBehaviour
{
    public CubeRotation[] cube;
    public bool isWin = false;
   
    public void win()
    {
        
        for (int i = 0; i < cube.Length; i++)
        {
            
            if (cube[i].transform.localEulerAngles.x == 0 && cube[i].transform.localEulerAngles.y == 90 && Math.Round(cube[i].transform.localEulerAngles.z) == 270)
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
    public void Update()
    {
        
        if (isWin)
        { 
                //cube[2].transform.position = new Vector3((float)-0.824000001, (float)2.93899989, (float)4.40838623) * Time.deltaTime;
                cube[2].transform.position = Vector3.Lerp(cube[2].transform.position, new Vector3((float)-0.824000001, (float)2.938999, (float)4.40838623), Time.deltaTime * 0.9f);
         
            
        }
    }
}
