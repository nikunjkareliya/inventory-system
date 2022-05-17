using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField]
    public InventoryUI inventoryUI;

    public Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> loadouts; 
    public List<InventoryItem> inventory; 
    
    public static event System.Action<InventoryItem> OnItemAdded;
    public static event System.Action<InventoryItem> OnItemRemoved;

    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
        inventory = new List<InventoryItem>();              
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();        
    }

    private void Start()
    {        
        if (loadouts.Count > 0)
        {
            foreach (InventoryItem item in loadouts)
            {
                // Debug.Log("Loadouts: " + item.GetData().name + " Item count: " + item.stackSize);
                for (int i = 0; i < item.stackSize; i++) {
                    Add(item.GetData());
                }
            }
        }

        inventoryUI.Init();
    }

    public void Add(InventoryItemData data)
    {

        if (itemDictionary.TryGetValue(data, out InventoryItem item))
        {
            item.AddToStack();
            RaiseItemAdded(item);            
        }
        else
        {
            InventoryItem newItem = new InventoryItem();
            newItem.Init(data);            
            RaiseItemAdded(newItem);

            inventory.Add(newItem);
            itemDictionary.Add(data, newItem);            
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
