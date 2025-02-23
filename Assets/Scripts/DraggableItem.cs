using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAtferDrag;
    public Item item;
    public Image image;

    private void Start()
    {
        if (item != null)
            InitilizeItem(item);
        else
            Debug.LogWarning(gameObject.name + " is not set !!");
    }

    public void InitilizeItem(Item newItem)
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = newItem.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAtferDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAtferDrag);
        image.raycastTarget = true;

        Transform parent = gameObject.transform.parent;
        parent.parent.GetComponent<Cabinet>().CheckedItems();
    }
}