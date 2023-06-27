using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedSlot : MonoBehaviour
{
    private static string selectedSlot;
    private static GameObject selectedSlotGameObject;
    private static bool isSelected;
    internal static bool IsSelected() => isSelected;
    internal static GameObject Get() => selectedSlotGameObject;
    internal static void Set(string currentSelected)
    {
        selectedSlotGameObject = EventSystem.current.currentSelectedGameObject;
        if (currentSelected != selectedSlot)
        {
            selectedSlot = currentSelected;
            isSelected = false;
        }
        else
            isSelected = true;
    }
}
