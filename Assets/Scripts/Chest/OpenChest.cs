using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenChest : MonoBehaviour
{
    private Animator animator;

    public int itemID;
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.currentSelectedGameObject != null)
            if (SelectedSlot.Get().GetComponent<InventorySlot>().ItemID == itemID)
                animator.enabled = true;
    }
}
