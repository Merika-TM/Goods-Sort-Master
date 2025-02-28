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

    private Color baseColor;
    [HideInInspector] public Image image;
    [HideInInspector] public Transform parentAtferDrag;

    private void Start()
    {
        InitilizeItem();
    }

    private void InitilizeItem()
    {
        image = gameObject.GetComponent<Image>();
        baseColor = image.color;
        isItemActive = Random.Range(0, 2) == 0; // Random activate

        ItemActivityStatus(isItemActive);
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
            image.raycastTarget = true;
            transform.localPosition = new Vector3(0,-35,0);
            image.color = baseColor;
        }
        else
        {
            image.raycastTarget = false;
            transform.localPosition = new Vector3(0,0,0);

            #region Changing Color

            Color color = image.color;
            float h, s, v;
            Color.RGBToHSV(color, out h, out s, out v);
            v *= 0.15f;
            image.color = Color.HSVToRGB(h, s, v);

            #endregion
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