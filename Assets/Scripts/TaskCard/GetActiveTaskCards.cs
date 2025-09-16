using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;



[Serializable]
public class TaskCardData
{
    public string title;
    public string description;
    public float timeRemaining;
    public float[] position;
    public bool visible; 
}

public class TodoCardData
{
    // TodoList
    public string cardTitle;
    public bool visible;
    
    // Todocards
    public string[] todoCardTitles;
    public bool[] taskStatus;
}

public static class GetActiveTaskCards
{
    static List<string> titles = new List<string>();
    static List<bool> taskStatus = new List<bool>();
    public static void GetTaskCardData()
    {
        GameObject taskCardHolder = GameObject.Find("TaskCards");
        int childCount = taskCardHolder.transform.childCount;
     
        TaskCardData[] saveData = new TaskCardData[childCount];
       

        for (int i = 0; i < childCount; i++)
        {
            TaskCardScript taskCardScript = taskCardHolder.transform.GetChild(i).GetComponent<TaskCardScript>();
        
            saveData[i] = new TaskCardData
            {
                title = taskCardScript.cardTitle,
                description = taskCardScript.cardDescription,
                timeRemaining = taskCardScript.timeRemaining,
                position = new float[3]
                {
                    taskCardScript.gameObject.transform.position.x,
                    taskCardScript.gameObject.transform.position.y,
                    taskCardScript.gameObject.transform.position.z
                },
                visible = taskCardScript.visible
            };
        }

        TodoTaskListScript[] todoTaskSpawners = GameObject.FindObjectsByType<TodoTaskListScript>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        TodoCardData[] saveData2 = new TodoCardData[todoTaskSpawners.Length];
        for (int i = 0; i < todoTaskSpawners.Length; i++)
        {
         
            for (int j = 0; j < todoTaskSpawners[i].todoListTaskScripts.Count; j++)
            {
                titles.Add(todoTaskSpawners[i].todoListTaskScripts[j].titleField.text);
                taskStatus.Add(todoTaskSpawners[i].todoListTaskScripts[j].crossedOut); 
            }

            saveData2[i] = new TodoCardData
            {
                todoCardTitles = titles.ToArray(),
                taskStatus = taskStatus.ToArray(),
                cardTitle = todoTaskSpawners[i].todoListTitle.text,
                visible =  todoTaskSpawners[i].visible
            };
        }
        
        SaveAndLoadSystem.SaveData(saveData);
    }
}


