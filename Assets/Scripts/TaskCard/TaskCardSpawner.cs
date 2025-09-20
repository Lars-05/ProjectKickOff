using System;
using TMPro;
using Unity.Mathematics;
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


    public void Awake()
    {
        SaveData saveData = SaveAndLoadSystem.LoadData();
        if (saveData == null || saveData.taskCardData == null)
        {
            return;
        }
        
        TaskCardData[] taskCardSavedData = saveData.taskCardData;
        
        foreach (TaskCardData taskCardData in taskCardSavedData)
        {
           
            GameObject taskcard = Instantiate(taskCardPrefab, this.transform.position, Quaternion.identity,  objectToSpawnTaskCardUnder.transform);
            TaskCardScript taskcardScript = taskcard.GetComponent<TaskCardScript>();
            
            taskcardScript.ConfigureCard(taskCardData.title, taskCardData.description, taskCardData.timeRemaining, taskCardData.multiplier);
            taskcardScript.visible = taskCardData.visible;
            
            
            GameObject newTaskCardWidgetPrefab = Instantiate(taskCardWidgetPrefab, this.transform.position, Quaternion.identity, objectToSpawnTaskCardWidgetUnder.transform);
            TaskCardWidget newTaskCardWidgetPrefabScript = newTaskCardWidgetPrefab.GetComponent<TaskCardWidget>();
            newTaskCardWidgetPrefabScript.taskCardScript = taskcardScript;
            newTaskCardWidgetPrefabScript.titleField.text = taskCardData.title;
            
        }
    }

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
            taskcardScript.ConfigureCard(cardTitleField.text, cardDescriptionField.text, seconds, MathF.Floor(seconds / 360f));
            
            GameObject newTaskCardWidgetPrefab = Instantiate(taskCardWidgetPrefab, this.transform.position, Quaternion.identity, objectToSpawnTaskCardWidgetUnder.transform);
            TaskCardWidget newTaskCardWidgetPrefabScript = newTaskCardWidgetPrefab.GetComponent<TaskCardWidget>();
            newTaskCardWidgetPrefabScript.taskCardScript = taskcardScript;
            newTaskCardWidgetPrefabScript.titleField.text = cardTitleField.text;
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
