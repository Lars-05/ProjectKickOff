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
    
    public void Awake()
    {

        SaveData saveData = SaveAndLoadSystem.LoadData();
        if (saveData == null || saveData.todoCardData == null)
        {
            return;
        }

        TodoCardData[] savedTodoCardData = saveData.todoCardData;
        
        
        foreach (TodoCardData todoCardData in savedTodoCardData)
        {
            
            GameObject newTodoListPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnTodoListUnder.transform);
            TodoListScript newTodoListPrefabScript = newTodoListPrefab.GetComponent<TodoListScript>();
            newTodoListPrefabScript.visible = todoCardData.visible;
            newTodoListPrefabScript.ConfigureTodoList(todoCardData.cardTitle);
          

            for (int i = 0; i < todoCardData.todoCardTitles.Length; i++)
            {
                Debug.Log(todoCardData.todoCardTitles[i]);
                Debug.Log(todoCardData.taskStatus[i]);
                newTodoListPrefabScript.SpawnTodoTask(todoCardData.todoCardTitles[i], todoCardData.taskStatus[i]);
            }
            
            GameObject newTodoListWidgetPrefab = Instantiate(todoTaskWidgetPrefab, this.transform.position, Quaternion.identity, objectToSpawnWidgetUnder.transform);
            TodoListWidget newTodoListWidgetPrefabScript = newTodoListWidgetPrefab.GetComponent<TodoListWidget>();
            newTodoListWidgetPrefabScript.todoListScript = newTodoListPrefabScript;
            newTodoListWidgetPrefabScript.Configure(todoCardData.cardTitle, todoCardData.visible);
        }
    }
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


