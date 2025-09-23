using UnityEngine;

public class SidebarScript : MonoBehaviour
{
    [SerializeField] private GameObject buddyGarden;
    [SerializeField] private GameObject taskManager;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject plantShelf;

    private GameObject[] panels;

    private void Awake()
    {
        panels = new[] { buddyGarden, taskManager, shop, plantShelf };
    }

    private void ShowPanel(GameObject panelToShow)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false); 
        }
        panelToShow.SetActive(true); 
    }

    public void OnShopButtonPressed() => ShowPanel(shop);
    public void OnTaskManagerButtonPressed() => ShowPanel(taskManager);
    public void OnPlantShelfButtonPressed() => ShowPanel(plantShelf);
    public void OnBuddyGardenButtonPressed() => ShowPanel(buddyGarden);
}