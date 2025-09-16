using TMPro;
using UnityEngine;

public class TodoListSpawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI errorMessageField;
    [SerializeField] private TextMeshProUGUI cardTitleField;
    [SerializeField] private GameObject objectToSpawnTodoListUnder;
    [SerializeField] private GameObject objectToSpawnWidgetUnder;
    [SerializeField] private GameObject todoTaskPrefab; 
    [SerializeField] private GameObject todoTaskWidgetPrefab; 
    [SerializeField] private GameObject objectToDisable;
    
    private bool stringInputCorrect = false;
    
    public void CheckInput()
    {
        if (stringInputCorrect)
        {
            SetErrorMessage(string.Empty);
            GameObject newTodoListPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnTodoListUnder.transform);
            TodoListScript newTodoListPrefabScript = newTodoListPrefab.GetComponent<TodoListScript>();
            
            GameObject newTodoListWidgetPrefab = Instantiate(todoTaskWidgetPrefab, this.transform.position, Quaternion.identity, objectToSpawnWidgetUnder.transform);
            TodoListWidget newTodoListWidgetPrefabScript = newTodoListWidgetPrefab.GetComponent<TodoListWidget>();
            newTodoListWidgetPrefabScript.todoListScript = newTodoListPrefabScript;
            
            newTodoListWidgetPrefabScript.Configure(cardTitleField.text, true);
            newTodoListPrefabScript.ConfigureTodoList(cardTitleField.text);
            
            MakeInvisible();
        }
        else
        {
            SetErrorMessage("Title Empty");
        }
    }

    public void ReadStringInput(string input)
    {
        if (input == string.Empty)
        {
            stringInputCorrect = false;
            return;
        }
        stringInputCorrect = true;
    }
    
    public void SetErrorMessage(string errorMessage)
    {
        errorMessageField.text = errorMessage;
    }
    
    public void MakeVisible()
    {
        objectToDisable.SetActive(true);
    }
    
    public void MakeInvisible()
    {
        objectToDisable.SetActive(false);
    }
}


