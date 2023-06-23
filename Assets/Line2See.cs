using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Line2See : MonoBehaviour
{
    public MirrorRotate[] mirror;
    private bool see = false;
    private Vector3[] positions = new Vector3[2];

    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = positions.Length;
        lineRenderer.GetPositions(positions);


    }
    public void luch()
    {
        
        for (int i = 0; i < mirror.Length; i++)
        {
            if ((Math.Round(mirror[i].transform.localEulerAngles.x / 10) * 10 == 350))
            { }
            else
            {
                see = false;
                return;
            }
        }
        see = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        luch();
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (see)
        {
            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
        }
        else 
        {
            lineRenderer.positionCount = 0;
        }
        
    }
}
