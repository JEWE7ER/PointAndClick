using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    internal bool isEnd = false;

    public void EndAnimation()
    {
        isEnd = true;
    }
}
