using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInTransitionRoom : MonoBehaviour
{
    private bool fin = true;

    public TagManager tagManager;
    public GameObject exit;
    public GameObject spriteOpen;
    public GameObject spriteClose;

    public Vector3 rotating;

    void Start()
    {
        if (exit.activeSelf)
            exit.SetActive(false);
    }

    void Update()
    {
        if (tagManager.isWin && fin)
        {
            if (transform.localEulerAngles == rotating)
                fin = false;
            else
            {
                transform.localEulerAngles = rotating;
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
