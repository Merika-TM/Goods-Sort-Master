using UnityEngine.EventSystems;
using UnityEngine;

public class CabinetSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject droppedItem = eventData.pointerDrag;
            DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();

            draggableItem.parentAtferDrag = transform;
        }
    }
}