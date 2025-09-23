using UnityEngine;

public class SpawnBuddy : MonoBehaviour
{
    [SerializeField] private Sprite[] buddieSprites;
    [SerializeField] private GameObject spawnPoint; 
    [SerializeField] private GameObject buddyPrefab;

    public void Awake()
    { 
        SaveData saveData = SaveAndLoadSystem.LoadData(); 
        if(saveData == null)
            return;
    }
    
    public void SpawnBuddyWithID(int buddyID)
    { 
        GameObject newBuddyPrefab = Instantiate(buddyPrefab, spawnPoint.transform.position, Quaternion.identity);
        SpriteRenderer buddySpriteRenderer = newBuddyPrefab.GetComponent<SpriteRenderer>();
        buddySpriteRenderer.sprite = buddieSprites[buddyID];
    }
}
