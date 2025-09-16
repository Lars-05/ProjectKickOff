using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TodoTaskListScript : MonoBehaviour
{
    [SerializeField] private GameObject todoTaskPrefab;
    [SerializeField] private GameObject objectToSpawnUnder;
    [HideInInspector] public List<TodoListTaskScript> todoListTaskScripts = new List<TodoListTaskScript>();
    
    [HideInInspector] public TextMeshProUGUI todoListTitle;
    [HideInInspector] public bool visible = true;
  
    public void SpawnTodoTask()
    { 
        GameObject newTodoTaskPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
        TodoListTaskScript newTodoTaskPrefabScript = newTodoTaskPrefab.GetComponent<TodoListTaskScript>();
        todoListTaskScripts.Add(newTodoTaskPrefabScript);
    }
    
    
}
