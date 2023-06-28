using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StonksManager : MonoBehaviour
{

    internal bool isWin = false;

    private Camera cam;
    public GameObject stonksCollider;
    public NumberStone[] stonks;
    

    void Start()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        if (isWin && !cam.GetComponent<RotateRoom>().zoom)
            stonksCollider.SetActive(false);
    }

    internal void Win()
    {
        foreach (var Stone in stonks)
        {
            if (Stone.numberStone != Stone.slotID)
                return;
        }
        isWin = true;
    }
}