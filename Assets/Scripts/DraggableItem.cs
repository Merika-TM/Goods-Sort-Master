using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private bool isItemActive;

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
    public void SetActivate(bool isActive)
    {
        isItemActive = isActive;
        ItemActivityStatus(isItemActive);
    }

    public bool GetActivate()
    {
        return isItemActive;
    }
    private void ItemActivityStatus(bool state)
    {
        if (state)
        {
            //todo: active settings (scale, location, color brightness)
        }
        else
        {
            //todo: DeActive settings (scale, location, color brightness)
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAtferDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        transform.localScale = Vector3.one * 1.1f;
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAtferDrag);
        transform.localScale = Vector3.one;
        image.raycastTarget = true;

        Transform parent = gameObject.transform.parent;
        parent.parent.GetComponent<Cabinet>().CheckedItems();
    }
}