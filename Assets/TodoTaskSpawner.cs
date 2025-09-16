using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TodoListScript : MonoBehaviour
{
    [SerializeField] private GameObject todoTaskPrefab;
    [SerializeField] private GameObject objectToSpawnUnder;
    [SerializeField] private GameObject objectToDisable;
    //[HideInInspector] public List<TodoListTaskScript> todoListTaskScripts = new List<TodoListTaskScript>();
    
    public TextMeshProUGUI todoListTitle;
    [HideInInspector] public bool visible = true;

    public void ConfigureTodoList(string title)
    {
        todoListTitle.text = title;
    }
    
    public void SpawnTodoTask()
    { 
        GameObject newTodoTaskPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
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
