using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OpenKey()
    {
        animator.enabled = true;
    }
}
