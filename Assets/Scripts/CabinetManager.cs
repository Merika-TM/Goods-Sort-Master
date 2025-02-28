using System.Collections.Generic;
using UnityEngine;

public class CabinetManager : MonoBehaviour
{
    public List<DraggableItem> items;
    public List<Cabinet> cabinets;
    public List<CabinetSlot> cabinetSlots;

    void Start()
    {
        foreach (var obj in cabinets)
        {
            cabinetSlots.AddRange(obj.GetComponent<Cabinet>().GetSlots());
        }

        int slotIndex = 0;

        foreach (var item in items)
        {
            for (int i = 0; i < 3; i++)
            {
                int newSlotIndex;
                do
                {
                    newSlotIndex = Random.Range(0, cabinetSlots.Count);
                } while (newSlotIndex == slotIndex);
                slotIndex = newSlotIndex;
                
                InstantiateItem(item.gameObject, cabinetSlots[slotIndex].transform);
            }
        }
    }

    public void InstantiateItem(GameObject item, Transform slotTransform)
    {
        CabinetSlot slot = slotTransform.GetComponent<CabinetSlot>();
        
        if (slot != null && !slot.CanAcceptItem(item.GetComponent<DraggableItem>()))
        {
            bool itemPlaced = false;
            foreach (var cabinetSlot in cabinetSlots)
            {
                if (cabinetSlot.CanAcceptItem(item.GetComponent<DraggableItem>()))
                {
                    InstantiateItemInSlot(item, cabinetSlot.transform);
                    itemPlaced = true;
                    break;
                }
            }

            if (!itemPlaced)
            {
                Debug.Log("No available slot to spawn the item.");
            }

            return;
        }

        InstantiateItemInSlot(item, slotTransform);
    }

    private void InstantiateItemInSlot(GameObject item, Transform slotTransform)
    {
        GameObject S = Instantiate(item, slotTransform);
        S.transform.localPosition = Vector3.zero;

        DraggableItem draggableItem = S.GetComponent<DraggableItem>();
        if (draggableItem != null && draggableItem.GetActivate())
        {
            draggableItem.transform.SetAsLastSibling(); // آخرین فرزند می‌شود
        }
    }
}