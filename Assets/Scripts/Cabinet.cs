using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet : MonoBehaviour
{
    public List<CabinetSlot> slots;
    public List<GameObject> itemGameObjects;
    
    private void Start()
    {
        int slotIndex = 0;
    
        foreach (var item in itemGameObjects)
        {
            slots[slotIndex].InstantiateItem(item);
            slotIndex = (slotIndex + 1) % slots.Count;
        }
    }

    public void CheckedItems()
    {
        int grandchildrenCount = CountGrandchildren(transform, out List<string> grandchildrenNames);

        if (grandchildrenCount == 3)
        {
            if (HaveSameNames(grandchildrenNames))
            {
                DestroyItems(gameObject.transform);
            }
        }
    }

    private int CountGrandchildren(Transform parent, out List<string> grandchildrenNames)
    {
        int count = 0;
        grandchildrenNames = new List<string>();
        
        foreach (Transform child in parent)
        {
            foreach (Transform grandchild in child)
            {
                count++;
                grandchildrenNames.Add(grandchild.name);
            }
        }
        
        return count;
    }
    
    bool HaveSameNames(List<string> names)
    {
        if (names.Count == 0)
        {
            return false;
        }
        
        string firstName = names[0];

        foreach (string name in names)
        {
            if (name != firstName)
            {
                return false;
            }
        }
        
        return true;
    }

    private void DestroyItems(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            foreach (Transform grandchild in child)
            {
                grandchild.GetComponent<FadeItem>().StartFade();
            }
        }
        
        GameManager.Instance.CheckedGameState();
    }
}
