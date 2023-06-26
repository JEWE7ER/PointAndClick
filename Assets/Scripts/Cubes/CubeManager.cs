using System;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    internal bool isWin = false;

    private bool isWinPosition = false;
    private Camera cam;
    private Vector3 stonePosition;
    private Vector3 targetPosition;//new Vector3((float)-0.803000008, (float)4.19700003, (float)4.40838623);

    public GameObject cubeCollider;
    public GameObject stone;
    public CubeRotation[] cubes;

    void Start()
    {
        cam = Camera.main;
        stonePosition = stone.transform.position;
        targetPosition = new Vector3(transform.position.x, 1.68f, transform.position.z);
    }

    public void Update()
    {

        if (isWin && !isWinPosition)
        {
            foreach (var cube in cubes)
                cube.transform.position = Vector3.MoveTowards(cube.transform.position, targetPosition, Time.deltaTime * 0.3f);
            isWinPosition = true;
        }
        if (!cam.GetComponent<RotateRoom>().zoom && stonePosition != stone.transform.position)
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
}
