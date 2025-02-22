using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAtferDrag;
    public Item item;
    public Image Image;

    private void Start()
    {
        if (item != null)
            InitilizeItem(item);
        else
            Debug.LogWarning(gameObject.name + " is not set !!");
    }

    public void InitilizeItem(Item newItem)
    {
        Image = gameObject.GetComponent<Image>();
        Image.sprite = newItem.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAtferDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAtferDrag);
        Image.raycastTarget = true;
    }
}