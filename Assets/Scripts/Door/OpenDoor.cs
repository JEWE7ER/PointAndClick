using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameObject exit;
    private TagManager tagManager;
    private GameObject spriteOpen;
    private GameObject spriteClose;

    public Vector3 rotating;
    // Start is called before the first frame update
    void Start()
    {
        tagManager = GameObject.FindGameObjectWithTag("TagManager").GetComponent<TagManager>();
        spriteOpen = GameObject.FindGameObjectWithTag("SpriteOpen");
        spriteClose = GameObject.FindGameObjectWithTag("SpriteClose");
        exit = GameObject.FindGameObjectWithTag("Exit");
        if (exit.activeSelf)
            exit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tagManager.isWin)
        {
            transform.Rotate(rotating);
            exit.SetActive(true);
            if (spriteClose.activeSelf)
            {
                spriteClose.SetActive(false);
                spriteOpen.SetActive(true);
            }
            tagManager.isWin = false;
        }
        
    }
}
