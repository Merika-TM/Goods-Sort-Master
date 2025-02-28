using UnityEngine.EventSystems;
using UnityEngine;

public class CabinetSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem == null) return;

        DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
        if (draggableItem == null) return;

        if (CanAcceptItem(draggableItem))
        {
            draggableItem.transform.SetParent(transform);
            draggableItem.transform.localPosition = new Vector3(0,-35,0);
            draggableItem.parentAtferDrag = transform;
            gameObject.GetComponentInParent<Cabinet>().CheckedLastItem();
        }
    }

    public bool CanAcceptItem(DraggableItem newItem)
    {
        int lastChildIndex = transform.childCount - 1;
        if (lastChildIndex >= 0)
        {
            Transform lastChild = transform.GetChild(lastChildIndex);
            DraggableItem lastDraggableItem = lastChild.GetComponent<DraggableItem>();
            if (lastDraggableItem != null && lastDraggableItem.GetActivate())
            {
                return false;
            }
        }

        return true;
    }
}