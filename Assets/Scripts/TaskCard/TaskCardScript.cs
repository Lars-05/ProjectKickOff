using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskCardScript : MonoBehaviour
{
    [HideInInspector] public string cardTitle;
    [HideInInspector] public string cardDescription;
    [HideInInspector] public float timeRemaining = 0;
    [HideInInspector] public bool visible = true;
    [HideInInspector] public TaskCardWidget taskCardWidget;
    private bool stopCountdown = true;
    
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private TextMeshProUGUI cardTitleField;
    [SerializeField] private TextMeshProUGUI cardDescriptionField;
    [SerializeField] private TextMeshProUGUI cardTimeField;
    [SerializeField] private TextMeshProUGUI startStopField;
    
    public void ConfigureCard(string title, string description, float seconds)
    {
        cardTitleField.text = title;
        cardDescriptionField.text = description;
        cardDescription = description;
        cardTitle = title;

        int hours = (int)seconds / 3600;
        int minutes = (int)seconds % 3600 / 60;
        cardTimeField.text = string.Format("{0:00}:{1:00}", hours, minutes);
        timeRemaining = seconds; 
    }
    
    public void ToggleCountdown()
    {
        if (stopCountdown) { stopCountdown = false; startStopField.text = "Stop";}
        else { stopCountdown = true; startStopField.text = "Start";}
    }
    
    private void Update()
    {
        if (!stopCountdown)
        {
            CountDown();
        }
    }

    private void CountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int displayHours = (int)(timeRemaining / 3600);
            int displayMinutes = (int)(timeRemaining % 3600 / 60);

            cardTimeField.text = string.Format("{0:00}:{1:00}", displayHours, displayMinutes);
        }
        else
        {
            cardTimeField.text = "00:00";
        }
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
