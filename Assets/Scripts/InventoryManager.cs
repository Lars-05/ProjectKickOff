using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public static class InventoryManager
{
    public static UnityEvent OnItemAdded = new UnityEvent();
    public static Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        {"Normal Seed Pack", 1},
        {"Fruit Seed Pack", 1},
        {"Winter Seed Pack", 1},
        {"Summer Seed Pack", 1},
        {"Autumn Seed Pack", 1},
        {"Watering Cans", 2}
    };
    
    public static int GetItemCount(string item)
    {
        return inventory.TryGetValue(item, out int count) ? count : 0;
    }

    public static void AddItemToInventory(string item, int amount)
    {
        inventory[item] += amount;
        OnItemAdded.Invoke();
    }
    
    public static void RemoveItemFromInventory(string item, int amount)
    {
        inventory[item] -= amount;
        OnItemAdded.Invoke();
    }
    
    
}
