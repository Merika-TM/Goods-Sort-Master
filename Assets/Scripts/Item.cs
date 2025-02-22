using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public string itemName;
    public ItemType itemType;
    
    [Header("Only UI")]
    public bool draggableItem = true;
    
    [Header("Both")]
    public Sprite image;
    public Color color;
    
    public enum ItemType
    {
        Food,
        Animal,
        Fruit,
        Toy,
        Drink,
        Plant
    }
}
