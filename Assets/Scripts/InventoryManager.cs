using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Events;


public static class InventoryManager
{
    
    public static UnityEvent OnItemAdded = new UnityEvent();
    
    public static Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        {"Resolvant", 50},
        {"Spring Seed Pack", 0},
        {"Basic Seed Pack", 0},
        {"Fruit Seed Pack", 0},
        {"Winter Seed Pack", 0},
        {"Summer Seed Pack", 0},
        {"Autumn Seed Pack", 0},
        {"Watering Cans", 0}
    };
    

    public static void RecieveData()
    {
        SaveData saveData = SaveAndLoadSystem.LoadData();
        if (saveData.inventoryData == null)
        {
            return;
        }
        
        AddItemToInventory("Resolvant", saveData.inventoryData.Resolvant);
        AddItemToInventory("Basic Seed Pack", saveData.inventoryData.NormalSeedPack);
        AddItemToInventory("Spring Seed Pack", saveData.inventoryData.SpringSeedPack);
        AddItemToInventory("Fruit Seed Pack", saveData.inventoryData.FruitSeedPack);
        AddItemToInventory("Winter Seed Pack", saveData.inventoryData.FruitSeedPack);
        AddItemToInventory("Summer Seed Pack", saveData.inventoryData.FruitSeedPack);
        AddItemToInventory("Autumn Seed Pack", saveData.inventoryData.FruitSeedPack);
        AddItemToInventory("Watering Cans", saveData.inventoryData.WateringCans);
        
        
    }

    public static int GetItemCount(string itemName)
    {
        return inventory.TryGetValue(itemName, out int count)? count: 0;
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
