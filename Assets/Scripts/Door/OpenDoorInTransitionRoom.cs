using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInTransitionRoom : MonoBehaviour
{
    private bool fin = true;

    public ManagerMirror mirrorManager;
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
        if (mirrorManager.isWin && fin)
        {
            if (transform.position.z >= position.z)
                fin = false;
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime);
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
