using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;

    private void OnMouseDown()
    {        
        InventoryManager.Instance.Add(itemData);
        Destroy(gameObject);
    }
}
