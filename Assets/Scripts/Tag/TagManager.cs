using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagManager : MonoBehaviour
{
    public static Cube[] cubes;
    internal static bool isWin;

    internal static void Win()
    {
        foreach (var cube in cubes)
        {
            if (cube.number != cube.numberCell)
                return;
        }
        isWin = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            Debug.Log("Win");
        }
    }
}