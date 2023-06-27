using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{ 
    internal bool isFull;
    internal bool isClicked = false;
    internal Item SlotItem;
    internal int ItemID;

    private Image icon;
    private Button button;
    private ColorBlock colorsButton;


    void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SlotClicked);
        colorsButton = button.colors;
        colorsButton.pressedColor = button.colors.normalColor; 
        colorsButton.selectedColor = button.colors.normalColor;
        button.colors = colorsButton;

    }

    public void PutInSlot(Item item)
    {
        icon.sprite = item.icon;
        SlotItem = item;
        ItemID = item.index;
        icon.enabled = true;
        isFull = true;
    }
    private void SlotClicked()
    {
        if (isFull)
        {
            if (!button.name.Equals(EventSystem.current.currentSelectedGameObject.name))
                isClicked = false;
            if (!isClicked)
            {
                ItemInfo.instance.Open(SlotItem);
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

    private void ChangeColor()
    {
        if (!isClicked)
            colorsButton.pressedColor = button.colors.disabledColor;
        else
            colorsButton.pressedColor = button.colors.normalColor;

        button.colors = colorsButton;
    }
}
