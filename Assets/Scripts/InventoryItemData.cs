using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item Data", menuName = "SO/Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{    
    public string itemName;
    public ItemType itemType;     
    public Sprite icon;   
}

public enum ItemType {
    Weapon,
    Collectable,
    Currency
}