using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    [Header("Базвоые характеристики")]
    public string Name = " ";
    public string Description = "Описание предмета";
    public Sprite icon = null;
}