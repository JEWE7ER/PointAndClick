using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagManager : MonoBehaviour
{

    internal bool isWin;

    public Cube[] cubes;
    public int speed = 20;

    void Update()
    {
        if (isWin)
        {
            Debug.Log("Win");
        }
    }

    internal void Win()
    {
        foreach (var cube in cubes)
        {
            if (cube.number != cube.numberCell)
                return;
        }
        isWin = true;
    }
}