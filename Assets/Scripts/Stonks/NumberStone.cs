using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberStone : MonoBehaviour
{
    public StonksManager stonksManager;
    public int numberStone;
    public int[] itemID;
    public int slotID;

    private void OnMouseDown()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            InventorySlot slot = SelectedSlot.Get().GetComponent<InventorySlot>();
            slotID = slot.ItemID;
            foreach (var item in itemID)
            {
                if (slot.ItemID == item)
                {
                    Inventory.instance.DeleteSlot(slot);

                }
            }
        }
        stonksManager.Win();
    }

}
