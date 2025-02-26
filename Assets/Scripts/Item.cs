using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public string itemName;
    public ItemType itemType;
    
    [Header("Only UI")]
    
    [Header("Both")]
    public Sprite image;
    
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
