using System.Collections.Generic;
using UnityEngine;

public class SpawnBuddy : MonoBehaviour
{
    [SerializeField] private Sprite[] buddieSprites;
    [SerializeField] private GameObject spawnPoint; 
    [SerializeField] private GameObject buddyPrefab;
    [SerializeField] private GameObject objectToSpawnUnder;
    [HideInInspector] public List<int> buddyIds = new List<int>();
    public void Awake()
    { 
      
        if(SaveAndLoadSystem.LoadData() == null)
            return;
        SaveData saveData = SaveAndLoadSystem.LoadData();

        foreach (var ID in saveData.buddyData.buddyIds)
        {
           SpawnBuddyWithID(ID);
        }
        
    }
    
    public void SpawnBuddyWithID(int buddyID)
    { 
        GameObject newBuddyPrefab = Instantiate(buddyPrefab, spawnPoint.transform.position, Quaternion.identity, objectToSpawnUnder.transform);
        SpriteRenderer buddySpriteRenderer = newBuddyPrefab.GetComponentInChildren<SpriteRenderer>();
        buddySpriteRenderer.sprite = buddieSprites[buddyID];
        buddyIds.Add(buddyID);
    }
}
