using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInTransitionRoom : MonoBehaviour
{
    private bool fin = true;
    private Camera cam;

    public ManagerMirror mirrorManager;
    public GameObject exit;
    public GameObject spriteOpen;
    public GameObject spriteClose;

    public Vector3 position;

    void Start()
    {
        cam = Camera.main;
        if (exit.activeSelf)
            exit.SetActive(false);
    }

    void Update()
    {
        if (mirrorManager.isWin && fin)
        {
            cam.GetComponent<RotateRoom>().zoom = true;
            if (transform.localPosition.x <= position.x)
            {
                fin = false;
                gameObject.SetActive(false);
                cam.GetComponent<RotateRoom>().zoom = false;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, position, Time.deltaTime);
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
