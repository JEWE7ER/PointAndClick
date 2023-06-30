using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    private GameObject parent;

    public Canvas text;

    internal void ShowText()
    {
        Instantiate(text);
        text.worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        //parent = GameObject.FindGameObjectWithTag("UIBox");
        //text.transform.parent = parent.transform;
        //text.transform.SetAsFirstSibling();
    }
    internal void HideText()
    {
        text.enabled = false;
        DestroyImmediate(text, true);
    }
}
