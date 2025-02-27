using UnityEngine.EventSystems;
using UnityEngine;

public class CabinetSlot : MonoBehaviour, IDropHandler
{

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
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<DraggableItem>().GetActivate())
                {
                    draggableItem.transform.SetParent(draggableItem.parentAtferDrag);
                    draggableItem.transform.localPosition = Vector3.zero;                    
                }
                else
                {
                    draggableItem.parentAtferDrag = transform;
                    draggableItem.transform.SetParent(transform);
                    draggableItem.transform.localPosition = Vector3.zero;
                }
   
            }
        }
    }
}