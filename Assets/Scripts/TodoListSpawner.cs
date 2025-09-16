using TMPro;
using UnityEngine;

public class TodoListSpawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI errorMessageField;
    [SerializeField] private TextMeshProUGUI cardTitleField;
    [SerializeField] private GameObject objectToSpawnUnder;
    [SerializeField] private GameObject todoTaskPrefab; 
        
    private bool intInputCorrect = false;
    private bool stringInputCorrect = false;
    
    public void CheckInput()
    {
        if (stringInputCorrect)
        {
            GameObject newTodoListPrefab = Instantiate(todoTaskPrefab, this.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
            TodoListTaskScript newTodoTaskPrefabScript = newTodoListPrefab.GetComponent<TodoListTaskScript>();
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
}


