using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskCardScript : IUpdaterBase
{
    [HideInInspector] public string cardTitle;
    [HideInInspector] public float multiplier;  
    [HideInInspector] public string cardDescription;
    [HideInInspector] public float timeRemaining = 0;
    [HideInInspector] public bool visible = true;
    [HideInInspector] public TaskCardWidget taskCardWidget;
    private bool stopCountdown = true;
    
    [SerializeField] private Slider progressSlider;
    [SerializeField] private GameObject startStopButton;
    [SerializeField] private GameObject claimRewardButton;
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private TextMeshProUGUI cardTitleField;
    [SerializeField] private TextMeshProUGUI cardDescriptionField;
    [SerializeField] private TextMeshProUGUI cardTimeField;
    [SerializeField] private TextMeshProUGUI startStopField;
    
    public void ConfigureCard(string title, string description, float seconds, float rewardMultiplier)
    {
        cardTitleField.text = title;
        cardDescriptionField.text = description;
        cardDescription = description;
        cardTitle = title;
        multiplier = rewardMultiplier; 

        int hours = (int)seconds / 3600;
        int minutes = (int)seconds % 3600 / 60;
        cardTimeField.text = string.Format("{0:00}:{1:00}", hours, minutes);
        timeRemaining = seconds;
        progressSlider.maxValue = seconds;
    }
    
    public void ToggleCountdown()
    {
        if (stopCountdown) { stopCountdown = false; startStopField.text = "Stop";}
        else { stopCountdown = true; startStopField.text = "Start";}
    }

    public override void SharedUpdate()
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
            progressSlider.value = timeRemaining;
            int displayHours = (int)(timeRemaining / 3600);
            int displayMinutes = (int)(timeRemaining % 3600 / 60);
        
            cardTimeField.text = string.Format("{0:00}:{1:00}", displayHours, displayMinutes);
        }
        else
        {
            cardTimeField.text = "00:00";
            startStopButton.SetActive(false);
            claimRewardButton.SetActive(true);
        }
    }

    public void ClaimReward()
    {
        InventoryManager.AddItemToInventory("Resolvant", 3);
        taskCardWidget.DeleteTaskCardAndWidget();
    }
    
    public void MakeVisible()
    {
        visible = true;
        SoundFXManager.Instance.PlaySoundFXClip("select_002", this.transform, 1, false);
        objectToDisable.SetActive(true);
    }
    
    public void MakeInvisible()
    {
        visible = false;
        SoundFXManager.Instance.PlaySoundFXClip("select_002", this.transform, 1, false);
        objectToDisable.SetActive(false);
    }
    
    
}
