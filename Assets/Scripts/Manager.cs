using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Cube02[] cube;
    public bool isWin;

    public void win()
    {
        for (int i = 0; i < cube.Length; i++)
        {
            if (cube[i].number != cube[i].numberCell)
                return;
        }
        isWin = true;
    }
    // Update is called once per frame
    public void Update()
    {
        if (isWin)
        {
            if (Input.GetKeyDown(KeyCode.Space)) ;
            SceneManager.LoadScene(0);
        }
    }
}