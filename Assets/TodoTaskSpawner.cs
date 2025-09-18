using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TodoListScript : MonoBehaviour
{
    [SerializeField] private GameObject todoTaskPrefab;
    [SerializeField] private GameObject objectToSpawnUnder;
    [SerializeField] private GameObject objectToDisable;
    public List<TodoListTask> todoListTaskScripts = new List<TodoListTask>();
    
    
    public TextMeshProUGUI todoListTitle;
    [HideInInspector] public bool visible = true;

    public void ConfigureTodoList(string title)
    {
        todoListTitle.text = title;
        if (visible) MakeVisible();
        else MakeInvisible();
    }
    
    public void SpawnNewTodoTask()
    { 
        GameObject newTodoTaskPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
        todoListTaskScripts.Add(newTodoTaskPrefab.GetComponent<TodoListTask>());
    }
    
    public void SpawnTodoTask(string title, bool completed)
    { 
     
        GameObject newTodoTaskPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
        TodoListTask newTodoTaskPrefabScript = newTodoTaskPrefab.GetComponent<TodoListTask>();
        newTodoTaskPrefabScript.todoListScript = this;
        todoListTaskScripts.Add(newTodoTaskPrefabScript);
        
        newTodoTaskPrefabScript.Configure(completed, title);
        
    }
    
    public void MakeVisible()
    {
        visible = true;
        objectToDisable.SetActive(true);
    }
    
    public void MakeInvisible()
    {
        visible = false;
        objectToDisable.SetActive(false);
    }
    
    
}
