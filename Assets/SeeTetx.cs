using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeTetx : MonoBehaviour
{
    public GameObject text1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        text1.gameObject.SetActive(true);
    }
}
