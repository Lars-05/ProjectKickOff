using UnityEngine;

public class TaskCardWidgetManager : MonoBehaviour
{
    [SerializeField] private GameObject taskCardWigidPrefab;
    public void AddNewTaskCard(TaskCardScript taskCardScript)
    {
        GameObject newTaskCardWigidPrefab = Instantiate(taskCardWigidPrefab, transform.position, Quaternion.identity, this.transform);
        TaskCardWidget taskCardWidget = newTaskCardWigidPrefab .GetComponent<TaskCardWidget>();
        taskCardWidget.titleField.text = taskCardScript.cardTitle;
        taskCardWidget.visible = true;
        taskCardWidget.taskCardScript = taskCardScript;
    }
    
    public void AddExistingTaskCard(TaskCardScript taskCardScript)
    {
        GameObject newTaskCardWigidPrefab = Instantiate(taskCardWigidPrefab, transform.position, Quaternion.identity, this.transform);
        TaskCardWidget taskCardWidget = newTaskCardWigidPrefab .GetComponent<TaskCardWidget>();
        taskCardWidget.titleField.text = taskCardScript.cardTitle;
        taskCardWidget.visible = true;
        taskCardWidget.taskCardScript = taskCardScript;
    }
}
