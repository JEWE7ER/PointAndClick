using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void DeleteSlot(InventorySlot currentSlot)
    {
        currentSlot.RemoveInSlot();
        if (inventorySlots.Count == 1 || currentSlot == inventorySlots.Last())
            goto RemoveFromList;
        else
        {
            for (int i = inventorySlots.IndexOf(currentSlot); i < inventorySlots.Count - 1; i++)
                inventorySlots[i].PutInSlot(inventorySlots[i + 1].SlotItem);
            inventorySlots.Last().RemoveInSlot();
        }
    RemoveFromList:
        inventorySlots.Remove(inventorySlots.Last());

    }
}
