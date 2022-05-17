using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public InventoryItemData inventoryItemData;
    public int stackSize;
    
    public void Init(InventoryItemData data)
    {
        inventoryItemData = data;
        AddToStack();
    }

    public InventoryItemData GetData()
    {        
        if (inventoryItemData != null) {
            return inventoryItemData;
        }
        return null;
    }

    public void AddToStack() {
        stackSize++;        
    }

    public void RemoveFromStack() {
        stackSize--;
    }
}
