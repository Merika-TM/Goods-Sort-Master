using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet : MonoBehaviour
{
    private RectTransform cabinetSize;
    private GridLayoutGroup placeHolder;

    private void Awake()
    {
        cabinetSize = gameObject.GetComponent<RectTransform>();
        placeHolder = gameObject.GetComponent<GridLayoutGroup>();
        placeHolder.cellSize = new Vector2(cabinetSize.rect.width / 3,cabinetSize.rect.height);
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
