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
            if (transform.localPosition.x <= position.x)
            {
                fin = false;
                gameObject.SetActive(false);
                if (!exit.activeSelf)
                    exit.SetActive(true);
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, position, Time.deltaTime);
                if (spriteClose.activeSelf)
                {
                    spriteClose.SetActive(false);
                    spriteOpen.SetActive(true);
                }
            }
        }

    }
}
