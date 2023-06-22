using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSwipe : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);

    private Vector2 tapPosition;
    private Vector2 swipeDelta;
    public float deadZone = 40;
    private bool isSwipe;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSwipe = true;
            tapPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
            ResetSwipe();

        CheckSwipe();
    }

    private void CheckSwipe()
    {
        swipeDelta = Vector2.zero;
        if (isSwipe)
        {
            if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - tapPosition;
        }
        if (swipeDelta.magnitude > deadZone)
        {
            if (SwipeEvent != null)
                SwipeEvent(swipeDelta.x>0 ? Vector2.right : Vector2.left);

            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        isSwipe = false;
        tapPosition = Vector2.zero;
        swipeDelta = Vector2.zero;
    }
}
