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
        for (int i = 0; i < cabnets.Count; i++)
        {
            cabinetSlots.AddRange(cabnets[i].GetComponent<Cabinet>().GetSlots());
        }
        
        int slotIndex = 0;
        foreach (var item in items)
        {
            InstantiateItem(item.gameObject,cabinetSlots[slotIndex].transform);
            slotIndex = (slotIndex + 1) % cabinetSlots.Count;
        }
    }
    public void InstantiateItem(GameObject item, Transform slotTransform)
    {
        GameObject S = Instantiate(item, slotTransform);
        S.transform.localPosition = Vector3.zero;
    }
    
}
