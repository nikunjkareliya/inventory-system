using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventoryUI inventoryUI;

    public Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory;
    //public Dictionary<InventoryItem, InventoryItemData> itemDictionary;

    public static InventoryManager Instance;

    public static event System.Action<InventoryItem> OnItemAdded;
    public static event System.Action<InventoryItem> OnItemRemoved;

    private void Awake()
    {
        Instance = this;
        inventory = new List<InventoryItem>();              
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        inventoryUI.Init();
    }
    
    //public void Add(InventoryItem item, InventoryItemData itemData)
    //{

    //    if (itemDictionary.ContainsKey(item))
    //    {
    //        item.AddToStack();
    //    }
    //    else
    //    {
    //        InventoryItem newItem = new InventoryItem();
    //        newItem.SetData(itemData);

    //        itemDictionary.Add(newItem, itemData);
    //        inventory.Add(newItem);
    //    }
    //}

    //public void Remove(InventoryItem item)
    //{
    //    if (itemDictionary.ContainsKey(item))
    //    {
    //        item.RemoveFromStack();

    //        if(item.stackSize == 0)
    //        {
    //            itemDictionary.Remove(item);
    //            inventory.Remove(item);
    //        }
    //    }
    //}

    public void Add(InventoryItemData data)
    {

        if (itemDictionary.TryGetValue(data, out InventoryItem item))
        {
            item.AddToStack();
            RaiseItemAdded(item);
            Debug.Log("Key exists");
        }
        else
        {
            InventoryItem newItem = new InventoryItem();
            newItem.Init(data);            
            RaiseItemAdded(newItem);

            inventory.Add(newItem);
            itemDictionary.Add(data, newItem);
            Debug.Log("Key does not exist");
        }
    }

    public void Remove(InventoryItemData data)
    {
        if (itemDictionary.TryGetValue(data, out InventoryItem item))
        {
            RaiseItemRemoved(item);
            item.RemoveFromStack();

            if (item.stackSize <= 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(data);
            }
        }

    }
    
    public static void RaiseItemAdded(InventoryItem item)
    {
        OnItemAdded?.Invoke(item);
    }

    public static void RaiseItemRemoved(InventoryItem item)
    {
        OnItemRemoved?.Invoke(item);
    }
}
