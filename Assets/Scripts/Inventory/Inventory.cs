using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Transform SlotsParent;
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    private void Start()
    {
        
        instance = this;
        //for (int i = 0; i < SlotsParent.childCount; i++)
        //{
        //    inventorySlots.Add(SlotsParent.GetChild(i).GetComponent<InventorySlot>());
        //}
    }

    public void PutInEmptySlot(Item item)
    {
        //for (int i = 0; i < inventorySlots.Count; i++)
        //{
        //    if (inventorySlots[i].SlotItem == null)
        //    {
        //        inventorySlots[i].PutInSlot(item);
        //        return;
        //    }
        //}
        InventorySlot slot = SlotsParent.GetChild(inventorySlots.Count).GetComponent<InventorySlot>();
        slot.PutInSlot(item);
        inventorySlots.Add(slot);

    }
}
