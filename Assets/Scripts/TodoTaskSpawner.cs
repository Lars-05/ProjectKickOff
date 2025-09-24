using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TodoListScript : IUpdaterBase
{
    [SerializeField] private GameObject todoTaskPrefab;
    [SerializeField] private GameObject objectToSpawnUnder;
    [SerializeField] private GameObject objectToDisable;
    public List<TodoListTask> todoListTaskScripts = new List<TodoListTask>();
    [SerializeField] private TextMeshProUGUI todoListTaskTitle;
    [HideInInspector] public TodoListWidget todoListWidgetScript;
    
    
    public TextMeshProUGUI todoListTitle;
    [HideInInspector] public bool visible = true;
    

    public void ConfigureTodoList(string title)
    {
        todoListTitle.text = title;
        if (visible) MakeVisible();
        else MakeInvisible();
    }

    public override void SharedUpdate()
    {
        foreach (var task in todoListTaskScripts)
        {
            task.crossedOut = true;
        }
    }

    public void SpawnNewTodoTask()
    { 
        GameObject newTodoTaskPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
        TodoListTask newTodoTaskPrefabScript = newTodoTaskPrefab.GetComponent<TodoListTask>();
        todoListTaskScripts.Add(newTodoTaskPrefabScript);
        newTodoTaskPrefabScript.todoListScript = this;
        newTodoTaskPrefabScript.Configure(false, todoListTaskTitle.text);
    }
    
    public void SpawnTodoTask(string title, bool completed)
    { 
     
        GameObject newTodoTaskPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
        TodoListTask newTodoTaskPrefabScript = newTodoTaskPrefab.GetComponent<TodoListTask>();
        newTodoTaskPrefabScript.todoListScript = this;
        todoListTaskScripts.Add(newTodoTaskPrefabScript);
        
        newTodoTaskPrefabScript.Configure(completed, title);
        
    }
    
    public void ClaimReward()
    {
        InventoryManager.AddItemToInventory("Resolvant", 3);
        todoListWidgetScript.DeleteTodoList();
    }
    
    public void MakeVisible()
    {
        visible = true;
        SoundFXManager.Instance.PlaySoundFXClip("select_002", this.transform, 1, false);
        objectToDisable.SetActive(true);
    }
    
    public void MakeInvisible()
    {
        visible = false;
        SoundFXManager.Instance.PlaySoundFXClip("select_002", this.transform, 1, false);
        objectToDisable.SetActive(false);
    }
    
    
}
