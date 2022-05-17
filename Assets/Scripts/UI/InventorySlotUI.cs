using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] Text textItemName;
    [SerializeField] Image imageItemIcon;

    [SerializeField] GameObject parentItemCount;
    [SerializeField] Text textItemCount;

    public void SetData(InventoryItem item) {
        textItemName.text = item.GetData().itemName.ToString();
        imageItemIcon.sprite = item.GetData().icon;

        if (item.stackSize == 0) {
            parentItemCount.SetActive(false);
        }

        textItemCount.text = item.stackSize.ToString();
    }

    public void AddInventorySlot(InventoryItem item) {

    }
}
