using UnityEngine;

public class SpawnTaskcard : MonoBehaviour
{
    [SerializeField] private Transform taskcardSpawn;
    [SerializeField] private GameObject taskcardPrefab;
    

    public void SpawnCard(string cardTitle, string cardDescription, int seconds, Vector3 position)
    {
        GameObject taskcard = Instantiate(taskcardPrefab, position, Quaternion.identity);
        TaskCardScript taskcardScript = taskcard.GetComponent<TaskCardScript>(); 
       
        taskcardScript.SetCardText(cardTitle, cardDescription, seconds);
       
    }
}
