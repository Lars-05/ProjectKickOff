using UnityEngine;

public class SidebarScript : MonoBehaviour
{
    [SerializeField] private GameObject buddyGarden;
    [SerializeField] private GameObject taskManager;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject plantShelf;
    
    public void OnShopButtonPressed()
    {
        plantShelf.SetActive(false);
        buddyGarden.SetActive(false);
        taskManager.SetActive(false);
        shop.SetActive(true);
    }
    public void OnTaskManagerButtonPressed()
    {
        plantShelf.SetActive(false);
        buddyGarden.SetActive(false);
        taskManager.SetActive(true);
        shop.SetActive(false);
    }
    public void OnPlantShelfButtonPressed()
    {
        plantShelf.SetActive(true);
        buddyGarden.SetActive(false);
        taskManager.SetActive(false);
        shop.SetActive(false);
    }
    public void OnBuddyGardenButtonPressed() 
    {
        plantShelf.SetActive(false);
        buddyGarden.SetActive(true);
        taskManager.SetActive(false);
        shop.SetActive(false);
    }
}