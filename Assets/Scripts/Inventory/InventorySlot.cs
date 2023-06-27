using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SelectedSlot;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
{ 
    
    internal Item SlotItem;
    internal int ItemID;


    private Image icon;
    private Image image;
    private bool isClicked = false;
    private bool isFull;
    private Button button;
    private ColorBlock colorsButton;
    private int siblingIndex;


    void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SlotClicked);
        colorsButton = button.colors;
        colorsButton.pressedColor = button.colors.normalColor; 
        colorsButton.selectedColor = button.colors.normalColor;
        button.colors = colorsButton;
        siblingIndex = transform.GetSiblingIndex();
        button.enabled = false;
        image = GetComponent<Image>();
        image.enabled = false;
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
        button.enabled = true;
        image.enabled = true;
    }

    public void RemoveInSlot() {  
        icon.sprite = null;
        SlotItem = null;
        ItemID = 0;
        icon.enabled = false;
        isFull = false;
        ItemInfo.instance.Close();
        EventSystem.current.SetSelectedGameObject(null);
        isClicked = false;
        button.enabled = false;
        image.enabled = false;
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
                ItemInfo.instance.Open(SlotItem, siblingIndex);
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
