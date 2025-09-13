using System;
using UnityEngine;

public class SpawnTaskcard : MonoBehaviour
{
    
    [SerializeField] private TaskCardWidgetManager taskCardWidgetManager;
    [SerializeField] private Transform taskcardSpawn;
    [SerializeField] private GameObject taskcardPrefab;
    [SerializeField] private GameObject parent;
    public void Awake()
    {
        var taskCardDatas = SaveAndLoadSystem.LoadData();
        if (taskCardDatas != null)
        {
            foreach (var taskCardData in taskCardDatas)
            {
                Vector3 position = new Vector3(taskCardData.position[0], taskCardData.position[1], taskCardData.position[2]);
                SpawnCard(taskCardData.title, taskCardData.description, Mathf.Ceil(taskCardData.timeRemaining),
                    position);
            }
        }
    }

    public void SpawnCard(string cardTitle, string cardDescription, float seconds, Vector3 position)
    {
        GameObject taskcard = Instantiate(taskcardPrefab, position, Quaternion.identity,  parent.transform);
        TaskCardScript taskcardScript = taskcard.GetComponent<TaskCardScript>(); 
        taskcardScript.SetCardText(cardTitle, cardDescription, seconds);
        taskCardWidgetManager.AddNewTaskCard(taskcardScript);
    }
}
