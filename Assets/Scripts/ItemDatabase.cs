using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDescription
{
    public string Name;
    public Texture2D image;
}


public class InventoryItem{
    public ItemDescription item;
    public int count;
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
            if (random > 0.5f) {
                result.Add(InventoryItem.Empty);
                continue;
            }

            var newItem = new InventoryItem();
            newItem.item = items[Random.Range(0, items.Count)];
            newItem.count = Random.Range(1, InventoryItem.MaxCount);
            result.Add(newItem);
        }
        return result;
    }
}
