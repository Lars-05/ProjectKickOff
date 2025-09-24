using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlantCard: IUpdaterBase
{

    [HideInInspector] public float timeRemaining = 0;
    [HideInInspector] public float totalTime;

    [HideInInspector] public int buddyID = 0;

    [HideInInspector] public bool isDone = false;
    [HideInInspector] public bool plantedBuddy = false;
    [HideInInspector] public bool needsWatering = false;
    
    [SerializeField] private float amountOfWateringTimeOff;

    [SerializeField] private Slider progressSlider;

    [SerializeField] private TextMeshProUGUI growingStatus;
    [SerializeField] private TextMeshProUGUI errorMessageField;
    [SerializeField] private TextMeshProUGUI cardTimeField;

    [SerializeField] private Sprite[] buddies;

    [SerializeField] private Image plantImage;
    [SerializeField] private Image buddyImage;

    
    [SerializeField] private GameObject harvestButtonGO;
    [SerializeField] private GameObject waterButtonGO;
    [SerializeField] private GameObject prePlantUI;
    [SerializeField] private GameObject proPlantUI;
    [SerializeField] private GameObject rewardUI;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject objectToDisable;

    [SerializeField] private Button plantingButton;
    [SerializeField] private TMP_Dropdown dropdown;

    public UnityEvent<int> OnBuddieClaimed;
    private bool visible = true;
    private string rarity;
    private string pack;
    
    public void Configure(float savedTimeRemaining, float savedtotalTime, int savedBuddyID, bool savedPlantedBuddy, bool savedNeedsWatering, bool savedIsDone)
    {
    
        isDone = savedIsDone;
        timeRemaining = savedTimeRemaining;
        totalTime = savedtotalTime;
        buddyID = savedBuddyID;
        plantedBuddy = savedPlantedBuddy;
        progressSlider.maxValue = totalTime;
        needsWatering = savedNeedsWatering;
        
        if( plantedBuddy && !isDone)
        {
            if (needsWatering)
            {
                growingStatus.text = "Your Buddy Needs Watering!";
                waterButtonGO.SetActive(true);
                progressSlider.value = timeRemaining;
                int displayHours = (int)(timeRemaining / 3600);
                int displayMinutes = (int)(timeRemaining % 3600 / 60);
                cardTimeField.text = string.Format("{0:00}:{1:00}", displayHours, displayMinutes);
            }
            growingStatus.text = "Your Buddy Is Growing!";
            prePlantUI.SetActive(false);
            proPlantUI.SetActive(true);
            
        }
        else if (plantedBuddy && isDone)
        {
            buddyImage.sprite = buddies[buddyID];
            prePlantUI.SetActive(false);
            proPlantUI.SetActive(false);
            rewardUI.SetActive(true);
            isDone = true;
        }
        

    }
    public override void SharedUpdate()
    {
        plantingButton.interactable = dropdown.options.Count > 0; 
        if (plantedBuddy)
        {
            CountDown();
        }
    }
    
    public void PlantBuddy()
    {
        SoundFXManager.Instance.PlaySoundFXClip("dirt1", this.transform, 1, false);
        plantedBuddy = true;
        prePlantUI.SetActive(false);
        pack = dropdown.options[dropdown.value].text;
        growingStatus.text = "Your Buddy Is Growing!";
        proPlantUI.SetActive(true);
        AssignBuddy();
    }
    
    private void AssignBuddy()
    {
        int randNumber = Random.Range(0, 101);

        switch (randNumber)
        {
            case < 80:
                rarity = "Common";
                timeRemaining =  20;
                totalTime = 20;
            break;
            
            case < 95:
                rarity = "Rare";
                timeRemaining =  20;
                totalTime =  20;
            break;
            
           default:
                rarity = "Epic";
                timeRemaining =  20;
                totalTime =  20;
            break;
        }
        progressSlider.maxValue = totalTime;
        
        switch (pack)
        {
             case "Normal Seed Pack":
                switch (rarity)
                {
                    case  "Common":
                        if(Random.Range(0, 2) == 1)
                            buddyID = 0;
                        else 
                            buddyID = 1;
                        break;
                    case  "Rare":
                        buddyID = 2;
                        break;
                    case  "Epic":
                        buddyID = 3;
                        break;
                }
            break; 
            
            case "Fruit Seed Pack":
                switch (rarity)
                {
                    case  "Common":
                        if(Random.Range(0, 2) == 1)
                            buddyID = 4;
                        else 
                            buddyID = 5;
                        break;
                    case  "Rare":
                        buddyID = 6;
                        break;
                    case  "Epic":
                        buddyID = 7;
                        break;
                }
            break;
            
            case "Winter Seed Pack":
                switch (rarity)
                {
                    case  "Common":
                        if(Random.Range(0, 2) == 1)
                            buddyID = 8;
                        else 
                            buddyID = 9;
                        break;
                    case  "Rare":
                        buddyID = 10;
                        break;
                    case  "Epic":
                        buddyID = 11;
                    break;
                }
            break; 
            
            
            case "Summer Seed Pack":
                switch (rarity)
                {
                    case  "Common":
                        if(Random.Range(0, 2) == 1)
                            buddyID = 12;
                        else 
                            buddyID = 13;
                        break;
                    case  "Rare":
                        buddyID = 14;
                        break;
                    case  "Epic":
                        buddyID = 15;
                        break;
                }
            break;
            
            case "Autumn Seed Pack":
                switch (rarity)
                {
                    case  "Common":
                        if(Random.Range(0, 2) == 1)
                            buddyID = 16;
                        else 
                            buddyID = 17;
                        break;
                    case  "Rare":
                        buddyID = 18;
                        break;
                    case  "Epic":
                        buddyID = 19;
                        break;
                }
            break; 
            
            case "Spring Seed Pack":
                switch (rarity)
                {
                    case  "Common":
                        if(Random.Range(0, 2) == 1)
                            buddyID = 20;
                        else 
                            buddyID = 21;
                        break;
                    case  "Rare":
                        buddyID = 22;
                        break;
                    case  "Epic":
                        buddyID = 23;
                        break;
                }
            break;
            
        }
    }
    private void CountDown()
    {
        if (!plantedBuddy || needsWatering)
        {
            return;
        }
        if (timeRemaining > 0)
        {
            progressSlider.value = timeRemaining;
            timeRemaining -= Time.deltaTime;
            int displayHours = (int)(timeRemaining / 3600);
            int displayMinutes = (int)(timeRemaining % 3600 / 60);
            cardTimeField.text = string.Format("{0:00}:{1:00}", displayHours, displayMinutes);
            int progressValue = Mathf.RoundToInt(timeRemaining);

            
            if (progressValue % 10 == 0 && Mathf.RoundToInt(timeRemaining) != totalTime && timeRemaining > 1) 
            {
                growingStatus.text = "Your Buddy Needs Watering!"; 
                needsWatering = true;
                waterButtonGO.SetActive(true);
            }
        }
        else
        {
            timeRemaining = 0f;
            cardTimeField.text = "00:00";
            growingStatus.text = "Your Buddy Is Ready For Harvest!";
            harvestButtonGO.SetActive(true);
        }
    }

    public void Water()
    {
  ;     
        if (InventoryManager.GetItemCount("Watering Cans") >0)
        {
            SoundFXManager.Instance.PlaySoundFXClip("water_pouring2", this.transform, 1, false);
            timeRemaining -= 5;
            needsWatering = false;
            growingStatus.text = "Your Buddy Is Growing!"; 
            waterButtonGO.SetActive(false);
            InventoryManager.RemoveItemFromInventory("Watering Cans", 1);
            errorMessageField.text = string.Empty;
            return;
        }
        errorMessageField.text = "You Have No Watering Cans!";
    }
    
    public void Harvest()
    {
        SoundFXManager.Instance.PlaySoundFXClip("cheerful_sound1", this.transform, 1, false);
        proPlantUI.SetActive(false);
        plantedBuddy = false;
        harvestButtonGO.SetActive(false);
        //indicator.SetActive(false);
        buddyImage.sprite = buddies[buddyID];
        rewardUI.SetActive(true);
        isDone = true;
        growingStatus.text = "You've Got A New Buddy!"; 
    }
    
    public void ClaimReward()
    {
        SoundFXManager.Instance.PlaySoundFXClip("BadBoop", this.transform, 1, false);
        plantedBuddy = false;
        rewardUI.SetActive(false);
        prePlantUI.SetActive(true);
        buddyImage.sprite = null;
        isDone = false;
        growingStatus.text = "Plant A buddy!";
        OnBuddieClaimed.Invoke(buddyID);
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
