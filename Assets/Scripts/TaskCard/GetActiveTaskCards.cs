using System;
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

public static class GetActiveTaskCards
{
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
                    taskCardScript.transform.position.x,
                    taskCardScript.transform.position.y,
                    taskCardScript.transform.position.z
                },
                visible = taskCardScript.visible
            };
        }
        
        SaveAndLoadSystem.SaveData(saveData);
    }
}


