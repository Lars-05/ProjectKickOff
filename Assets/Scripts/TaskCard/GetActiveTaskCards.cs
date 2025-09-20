using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



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
public class CurrencyData
{
    public int coins;
    public int wateringCans;
    public int seedpackets;
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
    public TodoCardData[] todoCardData;
    public TaskCardData[] taskCardData;
}

public static class GetUserData
{
    
    public static void GetUserSaveData()
    {
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

        SaveData saveData = new SaveData();
        saveData.todoCardData = todoListSaveData;
        saveData.taskCardData = taskCardSaveData;

        SaveAndLoadSystem.SaveData(saveData);
    }
}


