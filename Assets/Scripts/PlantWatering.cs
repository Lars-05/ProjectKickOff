using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantWatering : IUpdaterBase
{
    public float timeRemaining = 0;
    
    [SerializeField] private TextMeshProUGUI cardTimeField;
    [SerializeField] private Sprite[] stages;
    [SerializeField] private Image plantImage;
    private bool stopCountdown = true;
    private int stageOfPlant = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }         
    
    public override void SharedUpdate()
    {
        if (!stopCountdown)
        {
            CountDown();
        }
    }

    // private void Update()
    // {
    //     if (!stopCountdown)
    //     {
    //         CountDown();
    //     }
    // }

    public void WateringPlant()
    {
        stageOfPlant++;
        timeRemaining = 10;
        stopCountdown = false;
        StartCoroutine(Growing());
    }

    IEnumerator Growing()
    {
        yield return new WaitForSeconds(timeRemaining);
        plantImage.sprite = stages[stageOfPlant];
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
