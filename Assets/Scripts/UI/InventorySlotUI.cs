using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Text textItemName;
    [SerializeField] Image imageItemIcon;

    [SerializeField] GameObject parentItemCount;
    [SerializeField] Text textItemCount;

    public Transform parent;
    void Start() {
        parent = GameObject.Find("Content").transform;
    }

    public void SetData(InventoryItem item) {
        textItemName.text = item.GetData().itemName.ToString();
        imageItemIcon.sprite = item.GetData().icon;

        if (item.stackSize == 0) {
            parentItemCount.SetActive(false);
        }

        textItemCount.text = item.stackSize.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //canvasGroup.blocksRaycasts = false;
        //canvasGroup.alpha = 0.6f;
        //transform.SetParent(InventoryManager.Instance.inventoryUI.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //GetComponent<RectTransform>().anchoredPosition += eventData.delta;
        //transform.position += (Vector3)eventData.delta;
        //Vector2 pos;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(parent as RectTransform, eventData.position, canvasParent.worldCamera, out pos);
        //Debug.Log("Pos: " + pos);
        //transform.localPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //canvasGroup.blocksRaycasts = true;
        //canvasGroup.alpha = 1;
    }
}
