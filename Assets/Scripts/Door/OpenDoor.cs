using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private TagManager tagManager;
    private GameManager gameManager;
    private bool fin = true;

    public GameObject exit;
    public GameObject spriteOpen;
    public GameObject spriteClose;

    public Vector3 rotating;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager.isDefault)
        {
            tagManager = GameObject.FindGameObjectWithTag("TagManager").GetComponent<TagManager>();
            if (exit != null)
                exit.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tagManager.isWin && fin)
        {
            if (transform.localEulerAngles == rotating)
                fin = false;
            else
            {
                transform.localEulerAngles = rotating;
                if (exit != null)
                    exit.SetActive(true);
                if (spriteClose != null)
                {
                    spriteClose.SetActive(false);
                    spriteOpen.SetActive(true);
                }
            }
        }
        
    }
}
