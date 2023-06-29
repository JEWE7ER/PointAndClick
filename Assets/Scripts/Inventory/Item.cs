using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    [Header("Базовые характеристики")]
    public string Name = " ";
    public int ItemID;
    public Sprite icon = null;
    public GameObject targetObject;
}