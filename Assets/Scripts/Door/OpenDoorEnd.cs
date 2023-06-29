using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorEnd : MonoBehaviour
{
    private bool fin = true;

    public StonksManager stoneManager;
    public GameObject exit;
    public GameObject spriteOpen;
    public GameObject spriteClose;

    public Vector3 position;

    void Start()
    {
        if (exit.activeSelf)
            exit.SetActive(false);
    }

    void Update()
    {
        if (stoneManager.isWin && fin)
        {
            if (transform.localPosition == position)
            {
                fin = false;
                gameObject.SetActive(false);
            }
            else
            {
                transform.localPosition = position;
                if (!exit.activeSelf)
                    exit.SetActive(true);
                if (spriteClose.activeSelf)
                {
                    spriteClose.SetActive(false);
                    spriteOpen.SetActive(true);
                }
            }
        }

    }
}
