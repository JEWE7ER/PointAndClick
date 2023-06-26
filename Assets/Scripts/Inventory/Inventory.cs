using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Transform SlotsParent;
    private InventorySlot[] inventorySlots = new InventorySlot[9];

    private void Start()
    {
        instance = this;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = SlotsParent.GetChild(i).GetComponent<InventorySlot>();
        }
    }

    public void PutInEmptySlot(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].SlotItem == null)
            {
                inventorySlots[i].PutInSlot(item);
                return;
            }
        }
    }
}
