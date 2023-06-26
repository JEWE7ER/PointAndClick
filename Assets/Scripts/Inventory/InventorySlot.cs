using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item SlotItem;
    Image icon;
    Button button;

    private void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SlotClicked);
    }

    public void PutInSlot(Item item)
    {
        icon.sprite = item.icon;
        SlotItem = item;
        icon.enabled = true;
    }
    void SlotClicked()
    {
        ItemInfo.instance.Open(SlotItem);
    }

}
