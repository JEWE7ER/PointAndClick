using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SelectedSlot;

public class InventorySlot : MonoBehaviour
{ 
    internal bool isFull;
    internal bool isClicked = false;
    internal Item SlotItem;
    internal int ItemID;

    private Image icon;
    private Button button;
    private ColorBlock colorsButton;
    private int sibilingIndex;


    void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SlotClicked);
        colorsButton = button.colors;
        colorsButton.pressedColor = button.colors.normalColor; 
        colorsButton.selectedColor = button.colors.normalColor;
        button.colors = colorsButton;
        sibilingIndex = transform.GetSiblingIndex();
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null && SelectedSlot.Get() != null)
        {
            if (isClicked)
            {
                EventSystem.current.SetSelectedGameObject(SelectedSlot.Get());
            }
        }
    }

    public void PutInSlot(Item item)
    {
        icon.sprite = item.icon;
        SlotItem = item;
        ItemID = item.ItemID;
        icon.enabled = true;
        isFull = true;
    }

    private void SlotClicked()
    {
        if (isFull)
        {
            SelectedSlot.Set(EventSystem.current.currentSelectedGameObject.name);
            if (!SelectedSlot.IsSelected())
                isClicked = false;
            if (!isClicked)
            {
                ItemInfo.instance.Open(SlotItem, sibilingIndex);
                isClicked = true;
                colorsButton.selectedColor = button.colors.disabledColor;
                button.colors = colorsButton;
            }
            else
            {
                ItemInfo.instance.Close();
                EventSystem.current.SetSelectedGameObject(null);
                isClicked = false;
                //colorsButton.selectedColor = button.colors.normalColor;
            }
        }
        else
            EventSystem.current.SetSelectedGameObject(null);
        
    }
}
