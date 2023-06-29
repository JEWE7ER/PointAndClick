using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberStone : MonoBehaviour
{
    private GameObject cloneStone;

    public StonksManager stoneManager;
    public int numberStone;
    public int[] itemsID;
    public int slotID;
    [SerializeField] Vector3 positionStone;

    private void OnMouseDown()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            InventorySlot slot = SelectedSlot.Get().GetComponent<InventorySlot>();
            slotID = slot.ItemID;
            foreach (var itemID in itemsID)
            {
                if (slot.ItemID == itemID)
                {
                    cloneStone = Instantiate(slot.targetObject);//, positionStone, slot.targetObject.transform.rotation);
                    cloneStone.transform.parent = GameObject.FindGameObjectWithTag("BoxStone").transform.parent;
                    cloneStone.transform.localPosition = positionStone;
                    Inventory.instance.DeleteSlot(slot);
                    break;
                }
            }
        }
        stoneManager.Win();
    }

}
