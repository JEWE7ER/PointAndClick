using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    //private GameObject parent;

    public Canvas text;

    internal void ShowText()
    {
        //text.worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        text.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        Instantiate(text);
        
        //parent = GameObject.FindGameObjectWithTag("UIBox");
        //text.transform.parent = parent.transform;
        //text.transform.SetAsFirstSibling();
    }
    internal void HideText()
    {
        //text.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("TextStone"));
    }
}
