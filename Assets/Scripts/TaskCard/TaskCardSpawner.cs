using System;
using TMPro;
using UnityEngine;

public class TaskCardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject taskCardWidgetPrefab;
    [SerializeField] private GameObject taskCardPrefab;
    [SerializeField] private GameObject objectToDisable;
    
    [SerializeField] private GameObject objectToSpawnTaskCardUnder;
    [SerializeField] private GameObject objectToSpawnTaskCardWidgetUnder;
    
    [SerializeField] private TextMeshProUGUI errorMessageField;
    [SerializeField] private TextMeshProUGUI cardTitleField;
    [SerializeField] private TextMeshProUGUI cardDescriptionField;
    
    [SerializeField] private TMP_InputField cardTimeHoursField;
    [SerializeField] private TMP_InputField cardTimeMinutesField;
        
    private bool intInputCorrect = false;
    private bool stringInputCorrect = false;
    
    public void CheckInput()
    {
        int.TryParse(cardTimeHoursField.text.Trim(), out int hours);
        int.TryParse(cardTimeMinutesField.text.Trim(), out int minutes);
        int seconds = hours * 3600 + minutes * 60;
        
        if (seconds == 0)
        {
            SetErrorMessage("Duration Too Short");
            return;
        }
        
        if (intInputCorrect && stringInputCorrect)
        {
            SetErrorMessage(string.Empty);
            GameObject taskcard = Instantiate(taskCardPrefab, this.transform.position, Quaternion.identity,  objectToSpawnTaskCardUnder.transform);
            TaskCardScript taskcardScript = taskcard.GetComponent<TaskCardScript>();
            taskcardScript.ConfigureCard(cardTitleField.text, cardDescriptionField.text, seconds);
            
            GameObject newTaskCardWidgetPrefab = Instantiate(taskCardWidgetPrefab, this.transform.position, Quaternion.identity, objectToSpawnTaskCardWidgetUnder.transform);
            TaskCardWidget newTaskCardWidgetPrefabScript = newTaskCardWidgetPrefab.GetComponent<TaskCardWidget>();
            newTaskCardWidgetPrefabScript.taskCardScript = taskcardScript;
        
       
      
            
            MakeInvisible();
        }
        else if(!intInputCorrect)
        {
            SetErrorMessage("Duration Empty");
        }
        else if (!stringInputCorrect)
        {
            SetErrorMessage("Title/Description Empty");
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
    
    public void ReadIntInput(string input)
    {
        if (input == string.Empty)
        {
            intInputCorrect = false;
            return;
        }
        intInputCorrect = true;
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
