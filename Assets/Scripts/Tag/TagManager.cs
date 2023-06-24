using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagManager : MonoBehaviour
{

    internal bool isWin  = false;

    private Camera cam;
    private GameObject tagCollider;

    public Cube[] cubes;
    public int speed = 20;


    void Start()
    {
        cam = Camera.main;
        tagCollider = GameObject.FindGameObjectWithTag("Collider");
    }
    void Update()
    {
        if (isWin && !cam.GetComponent<RotateRoom>().zoom)
        {
            tagCollider.SetActive(false);
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