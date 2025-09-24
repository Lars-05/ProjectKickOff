using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class BuddyData
{
    public int[] buddyIds;
}


[Serializable]
public class PlantCardData
{
    public float timeRemaining;
    public float totalTime;
    public int buddyID;
    public bool needsWatering;
    public bool plantedBuddy;
    public bool isDone;
}

[Serializable]
public class TaskCardData
{
    public string title;
    public string description;
    public float timeRemaining;
    public float[] position;
    public float multiplier;
    public bool visible; 
}

[Serializable]
public class InventoryData
{
    public int Resolvant = 0;
    public int NormalSeedPack = 0;
    public int SpringSeedPack = 0;
    public int FruitSeedPack = 0;
    public int WinterSeedPack = 0;
    public int SummerSeedPack = 0;
    public int AutumnSeedPack = 0;
    public int WateringCans = 0;
}

[Serializable]
public class TodoCardData
{
    // TodoList
    public string cardTitle;
    public bool visible;
    
    // Todocards
    public string[] todoCardTitles;
    public bool[] taskStatus;
}
[Serializable]
public class SaveData
{
    public BuddyData buddyData;
    public TodoCardData[] todoCardData;
    public TaskCardData[] taskCardData;
    public PlantCardData[] plantData;
    public InventoryData inventoryData;
}

public static class GetUserData
{
    
    public static void SaveUserSaveData()
    {
        // Taskcards
        GameObject taskCardHolder = GameObject.Find("TaskCards");
        int childCount = taskCardHolder.transform.childCount;
     
        TaskCardData[] taskCardSaveData = new TaskCardData[childCount];
       

        for (int i = 0; i < childCount; i++)
        {
            TaskCardScript taskCardScript = taskCardHolder.transform.GetChild(i).GetComponent<TaskCardScript>();
        
            taskCardSaveData[i] = new TaskCardData
            {
                title = taskCardScript.cardTitle,
                description = taskCardScript.cardDescription,
                timeRemaining = taskCardScript.timeRemaining,
                multiplier = taskCardScript.multiplier,
                position = new float[3]
                {
                    taskCardScript.gameObject.transform.position.x,
                    taskCardScript.gameObject.transform.position.y,
                    taskCardScript.gameObject.transform.position.z
                },
                visible = taskCardScript.visible
            };
        }
        
        // TodoListCards
        TodoListScript[] todoLists = GameObject.FindObjectsByType<TodoListScript>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        TodoCardData[] todoListSaveData = new TodoCardData[todoLists.Length];
        
        for (int i = 0; i < todoLists.Length; i++)
        {
            List<string> titles = new List<string>();
            List<bool> taskStatus = new List<bool>();
            
            for (int j = 0; j < todoLists[i].todoListTaskScripts.Count; j++)
            {
                taskStatus.Add(todoLists[i].todoListTaskScripts[j].crossedOut);
                titles.Add(todoLists[i].todoListTaskScripts[j].titleField.text); 
                Debug.Log(todoLists[i].todoListTaskScripts[j].crossedOut);
            }
            
            todoListSaveData[i] = new TodoCardData
            {
                todoCardTitles = titles.ToArray(),
                taskStatus = taskStatus.ToArray(),
                cardTitle = todoLists[i].todoListTitle.text,
                visible =  todoLists[i].visible
            };
        }
        
        
        // Plants
        PlantCardManager plantCardManager = GameObject.FindFirstObjectByType<PlantCardManager>();
        PlantCardData[] plantsCardSaveData = new PlantCardData[plantCardManager.plantCards.Length];
        
        for (int i = 0; i < plantCardManager.plantCards.Length; i++)
        {
            
          
            plantsCardSaveData[i] = new PlantCardData()
            {
                timeRemaining = plantCardManager.plantCards[i].timeRemaining,
                totalTime = plantCardManager.plantCards[i].totalTime,
                buddyID = plantCardManager.plantCards[i].buddyID,
                needsWatering = plantCardManager.plantCards[i].needsWatering,
                plantedBuddy = plantCardManager.plantCards[i].plantedBuddy,
                isDone = plantCardManager.plantCards[i].isDone,
            };
        }
        
        // Inventory Data
        InventoryData inventorySaveData = new InventoryData
        {
            Resolvant = InventoryManager.GetItemCount("Resolvant"),
            SpringSeedPack = InventoryManager.GetItemCount("Spring Seed Pack "),
            NormalSeedPack = InventoryManager.GetItemCount("Normal Seed Pack"),
            FruitSeedPack = InventoryManager.GetItemCount("Fruit Seed Pack"),
            WinterSeedPack = InventoryManager.GetItemCount("Winter Seed Pack"),
            SummerSeedPack = InventoryManager.GetItemCount("Summer Seed Pack"),
            AutumnSeedPack = InventoryManager.GetItemCount("Autumn Seed Pack"),
            WateringCans = InventoryManager.GetItemCount("Watering Cans")
        };


        SpawnBuddy spawnBuddyScript = GameObject.FindFirstObjectByType<SpawnBuddy>();
        
        BuddyData BuddyData = new BuddyData
        {
            buddyIds = spawnBuddyScript.buddyIds.ToArray()
        }; 
        
        
        //Put All Into Single Class
        SaveData saveData = new SaveData();
        saveData.buddyData = BuddyData;
        saveData.inventoryData = inventorySaveData;
        saveData.todoCardData = todoListSaveData;
        saveData.taskCardData = taskCardSaveData;
        saveData.plantData = plantsCardSaveData;

        SaveAndLoadSystem.SaveData(saveData);
    }
}


