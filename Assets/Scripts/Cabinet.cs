using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet : MonoBehaviour
{
    public List<CabinetSlot> slots;

    private void Start()
    {
        Debug.Log("This Cabinet Has " + gameObject.transform.childCount);
    }

    public List<CabinetSlot> GetSlots()
    {
        return slots;
    }

    public void CheckedLastItem()
    {
        List<string> childsNames = new List<string>(); 
        List<bool> childsActivity = new List<bool>();

        foreach (var slot in slots)
        {
            if (slot.transform.childCount == 0) return;
            else
            {
                var childIndex = slot.gameObject.transform.childCount - 1;
                var child = slot.gameObject.transform.GetChild(childIndex);
                childsNames.Add(child.gameObject.GetComponent<DraggableItem>().itemName);
                childsActivity.Add(child.gameObject.GetComponent<DraggableItem>().GetActivate());
            }
        }

        bool allNamesEqual = new HashSet<string>(childsNames).Count == 1;
        bool allActivityEqual = new HashSet<bool>(childsActivity).Count == 1;
        
        if (allNamesEqual && allActivityEqual)
        {
            DestroyLastItems();
        }
    }
    
    private void DestroyLastItems()
    {
        foreach (var slot in slots)
        {
            var childIndex = slot.gameObject.transform.childCount - 1;
            var child= slot.gameObject.transform.GetChild(childIndex);
            child.GetComponent<FadeItem>().StartFade();
        }
        
        GameManager.Instance.CheckedGameState();
    }
}
