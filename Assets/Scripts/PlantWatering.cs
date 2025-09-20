using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlantWatering : IUpdaterBase
{
    public float timeRemaining = 0;
    
    [SerializeField] private TextMeshProUGUI cardTimeField;
    [SerializeField] private Sprite[] plants;
    [SerializeField] private float amountOfWateringTimeOff;
    [SerializeField] private Image plantImage;
    [SerializeField] private Button harvestSaveButton;
    [SerializeField] private GameObject indicator;
    [SerializeField] private TMP_Dropdown dropdown;
    private bool stopCountdown = true;
    private bool planted = false;
    private string rarity; 
    private string pack;
    private Dictionary<string, int> watering = new Dictionary<string, int>()
    {
        {"Spring", 1},
        {"Summer", 2},
        {"Autumn", 3},
        {"Winter", 4},
        {"Fruit", 5},
        {"Basic", 6}
    };
    // PlaceHolder
    [SerializeField] private float amountOfWateringCans;
    
    
    public override void SharedUpdate()
    {
        if (!stopCountdown)
        {
            CountDown();
        }
    }

    public void PlantingPlant()
    {
        if (!planted)
        {
            planted = true;
            int roll = Random.Range(0, 20);
            if (roll < 16)
            {
                rarity = "Common";
                timeRemaining = 60;
            }
            else if (roll < 19)
            {
                rarity = "Rare";
                timeRemaining = 120;
            }
            else
            {
                rarity = "Epic";
                timeRemaining = 240;
            }

            stopCountdown = false;
            pack = dropdown.options[dropdown.value].text;
            Debug.Log(pack);
            StartCoroutine(Growing());
        }
    }
    
    public void WateringPlant()
    {
        if (amountOfWateringCans > 0 && timeRemaining > amountOfWateringTimeOff)
        {
            timeRemaining -= amountOfWateringTimeOff;
            amountOfWateringCans -= 1;
        }
    }

    IEnumerator Growing()
    {
        yield return new WaitUntil(() => timeRemaining <= 0);
        Grow();
        Debug.Log("Grow");
    }

    private void Grow()
    {
        int packValue = watering[pack];
        
        if (rarity == "Common")
        {
            Debug.Log("Common");
            int index = Random.Range(0, 2);
            plantImage.sprite = plants[index * packValue];
        }
        else if (rarity == "Rare")
        {
            Debug.Log("Rare");
            plantImage.sprite = plants[2 * packValue];
        }
        else if (rarity == "Epic")
        {
            Debug.Log("Epic");
            plantImage.sprite = plants[3 * packValue];
        }

        harvestSaveButton.interactable = true;
        indicator.SetActive(true);
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

    
    public void Harvest()
    {
        planted = false;
        plantImage.sprite = null;
        harvestSaveButton.interactable = false;
        indicator.SetActive(false);
    }
}
