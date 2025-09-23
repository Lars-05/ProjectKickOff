using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ShowWidgets : MonoBehaviour
{
    [SerializeField] private GameObject taskWidgetsList; 
    [SerializeField] private GameObject todoListWidgetsList; 
    
    public void ShowTasks()
    {
        taskWidgetsList.SetActive(true);
        todoListWidgetsList.SetActive(false);
    }
 
    public void ShowTodoList()
    {
        taskWidgetsList.SetActive(false);
        todoListWidgetsList.SetActive(true);
    }
    
}
