using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI slotPrefab;
    public Transform inventoryRoot;
    public List<InventorySlotUI> listSlots;

    public void Init()
    {
        InventoryManager.OnItemAdded -= UpdateInventorySlots;
        InventoryManager.OnItemAdded += UpdateInventorySlots;
        //InventoryManager.OnItemRemoved += UpdateInventorySlots;

        CreateInventorySlots();
    }

    public void CreateInventorySlots()
    {
        for (int i = 0; i < InventoryManager.Instance.inventory.Count; i++)
        {
            InventorySlotUI slot = Instantiate(slotPrefab, inventoryRoot);
            slot.SetData(InventoryManager.Instance.inventory[i]);
            listSlots.Add(slot);
        }
    }

    public void UpdateInventorySlots(InventoryItem item)
    {                
        foreach (var slot in listSlots)
        {
            Destroy(slot.gameObject);
        }
        listSlots.Clear();

        Invoke("CreateInventorySlots", 0.01f); 
    }
}
