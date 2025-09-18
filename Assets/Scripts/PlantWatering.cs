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
    private bool stopCountdown = true;
    private Dictionary<string, int> watering = new Dictionary<string, int>()
    {
        {"Spring", 0},
        {"Summer", 1},
        {"Autumn", 2},
        {"Winter", 3},
        {"Fruit", 4},
        {"Basic", 5}
    };

    private string pack;
    
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
        timeRemaining = 60;
        stopCountdown = false;
        var dropdown = gameObject.GetComponent<TMP_Dropdown>();
        pack = dropdown.options[dropdown.value].text;
        
        Debug.Log(pack);
        StartCoroutine(Growing());
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
        int roll = Random.Range(0, 20);
        Debug.Log(roll);
        if (roll < 16)
        {
            Debug.Log("Common");
            int index = Random.Range(0, 2);
            plantImage.sprite = plants[index * packValue];
        }
        else if (roll < 19)
        {
            Debug.Log("Rare");
            plantImage.sprite = plants[2 * packValue];
        }
        else
        {
            Debug.Log("Epic");
            plantImage.sprite = plants[3 * packValue];
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
    
}
