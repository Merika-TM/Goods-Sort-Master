using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Food,
    Animal,
    Fruit,
    Toy,
    Drink,
    Plant
}
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemName;
    public ItemType itemType;
    [SerializeField] private bool isItemActive;
    
    [HideInInspector] public Image image;
    [HideInInspector] public Transform parentAtferDrag;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
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