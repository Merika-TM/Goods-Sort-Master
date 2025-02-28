using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetManager : MonoBehaviour
{
    public List<DraggableItem> items;
    public List<Cabinet> cabnets;
    public List<CabinetSlot> cabinetSlots;

    void Start()
    {
        foreach (var obj in cabnets)
        {
            cabinetSlots.AddRange(obj.GetComponent<Cabinet>().GetSlots());
        }

        int slotIndex = 0;
        int newSlotIndex;
        
        foreach (var item in items)
        {
            for (int i = 0; i < 3; i++)
            {
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
        GameObject S = Instantiate(item, slotTransform);
        S.transform.localPosition = Vector3.zero;
    }
}