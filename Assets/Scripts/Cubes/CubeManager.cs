using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    internal bool isWin = false;

    private bool isWinPosition = false;
    private Camera cam;
    private Vector3 stonePosition;
    private List<Vector3> cubeDefaultPositions = new List<Vector3>();
    private Vector3 targetPosition;//new Vector3((float)-0.803000008, (float)4.19700003, (float)4.40838623);

    public GameObject cubeCollider;
    public GameObject stone;
    public CubeRotation[] cubes;

    void Start()
    {
        cam = Camera.main;
        stonePosition = stone.transform.position;
        foreach (var cube in cubes)
            cubeDefaultPositions.Add(cube.transform.localEulerAngles);
    }

    public void Update()
    {

        if (isWin && !isWinPosition)
        {
            foreach (var cube in cubes)
            {
                targetPosition = new Vector3(cube.transform.position.x, 1.68f, cube.transform.position.z);
                cube.transform.position = Vector3.MoveTowards(cube.transform.position, targetPosition, Time.deltaTime);
                if (cube.transform.position == targetPosition)
                {
                    isWinPosition = true;
                    cube.gameObject.SetActive(false);
                }
            }
            
        }
        if (!cam.GetComponent<RotateRoom>().zoom && stone == null)
        {
            cubeCollider.SetActive(false);
        }
    }

    public void Win()
    {
        foreach (var cube in cubes)
            if (!(cube.transform.localEulerAngles.x == 0 && cube.transform.localEulerAngles.y == 90 &&
                Math.Round(cube.transform.localEulerAngles.z) == 270))
                return;
        isWin = true;

    }

    public void ReturnToDefault()
    {
        if (!isWin)
            for (int i = 0; i < cubes.Length; i++)
                cubes[i].transform.localEulerAngles = cubeDefaultPositions[i];
    }
}
