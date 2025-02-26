using UnityEngine.EventSystems;
using UnityEngine;

public class CabinetSlot : MonoBehaviour, IDropHandler
{

    public void InstantiateItem(GameObject item)
    {
        GameObject S = Instantiate(item, transform);
        S.transform.localPosition = Vector3.zero;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();

        if (transform.childCount == 0)
        {
            draggableItem.parentAtferDrag = transform;
            draggableItem.transform.SetParent(transform);
            draggableItem.transform.localPosition = Vector3.zero;
        }
        else
        {
            draggableItem.transform.SetParent(draggableItem.parentAtferDrag);
            draggableItem.transform.localPosition = Vector3.zero;
        }
    }
}