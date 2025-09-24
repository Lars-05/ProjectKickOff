using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TodoListTask : MonoBehaviour
{
    public TextMeshProUGUI titleField;
    [SerializeField] private Toggle crossedOutToggle;
    [HideInInspector] public bool crossedOut;
    [HideInInspector] public TodoListScript todoListScript;

    public void Configure(bool completed, string title)
    {

        crossedOutToggle.isOn = completed;
        titleField.text = title;
    }
    public void ToggleCrossout(bool completed)
    {
        if(completed){titleField.fontStyle = FontStyles.Strikethrough;
            crossedOut = true;
        }
        else {titleField.fontStyle = FontStyles.Normal;
            crossedOut = false;
        }
        todoListScript.TestIfAllCrossedOut();
    }
    
    public void DeleteTask()
    {
        todoListScript.todoListTaskScripts.Remove(this);
        Destroy(this.gameObject);
      
    }

    public void SaveTodoTaskName(string taskName)
    {
        titleField.text = taskName;
    }
        
}
