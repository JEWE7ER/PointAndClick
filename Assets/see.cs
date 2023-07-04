using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class see : MonoBehaviour
{
    public KeyCode Left; 
    public KeyCode Right;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Right) && i == 0 )
        {
            gameObject.SetActive(true);
            i += 1;
        }
        else if (Input.GetKey(Left) && i == 0)
        {     
            gameObject.SetActive(true);
            i += 1;
        }
    }
}
