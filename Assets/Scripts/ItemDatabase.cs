using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDescription
{
    public string Name;
    public Texture2D Image;
}


public class InventoryItem{
    public ItemDescription Item;
    public int Quantity;
    
    public bool isEmpty => this == Empty;

    public const int MaxCount = 50;
    public static readonly InventoryItem Empty = new InventoryItem();
}

[CreateAssetMenu(menuName = "Inventory/Items", order = 1)]
public class ItemDatabase: ScriptableObject
{
    //Configurable item data souce in the Unity Editor
    [SerializeField]
    private List<ItemDescription> items = new List<ItemDescription>();


    public List<InventoryItem> GetRandomItems(int count){
        var result = new List<InventoryItem>();
        for (int i = 0; i < count; i++)
        {
            var random = Random.Range(0, 1f);
            if random > 0.5f {
                result.Add(InventoryItem.Empty);
                continue;
            }

            var item = new InventoryItem();
            item.Item = items[Random.Range(0, items.Count)];
            item.Quantity = Random.Range(1, InventoryItem.MaxCount);
            result.Add(item);
        }
        return result;
    }
}
