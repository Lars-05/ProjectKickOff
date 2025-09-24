using UnityEngine;

public class SpecialDisable : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDisable;

    public void DisablePlantshelf()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
    
    public void EnablePlantshelf()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }
    }
}
