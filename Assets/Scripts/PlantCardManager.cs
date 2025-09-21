using System.Collections.Generic;
using UnityEngine;

public class PlantCardManager : MonoBehaviour
{
    public PlantCard[] plantCards; 
    private void Awake()
    {
        SaveData saveData = SaveAndLoadSystem.LoadData(); 
        if(saveData == null)
            return;

        for (int i = 0; i < saveData.plantData.Length; i++)
        {
            plantCards[i].Configure(saveData.plantData[i].timeRemaining, saveData.plantData[i].totalTime, saveData.plantData[i].buddyID, saveData.plantData[i].plantedBuddy , saveData.plantData[i].needsWatering, saveData.plantData[i].isDone);

        }
    }
}
