using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool fin = true;

    public TagManager tagManager;
    public GameObject exit;

    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        if (exit.activeSelf)
            exit.SetActive(false);
    }

    void Update()
    {
        if (tagManager.isWin && fin && !Camera.main.GetComponent<RotateRoom>().zoom)
        {
            if (transform.localPosition.y <= position.y)
            {
                fin = false;
                gameObject.SetActive(false);
                if (!exit.activeSelf)
                    exit.SetActive(true);
            }
            else
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, position, Time.deltaTime);
        }
        
    }
}
