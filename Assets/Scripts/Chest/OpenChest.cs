using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenChest : MonoBehaviour
{
    private Animator animator;
    public key key;
    public int itemID;
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.currentSelectedGameObject != null) {
            InventorySlot slot = SelectedSlot.Get().GetComponent<InventorySlot>();
            if (slot.ItemID == itemID)
            {
                key.OpenKey();
                Inventory.instance.DeleteSlot(slot);
                animator.enabled = true;

            }
        }
    }
}
