using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSeedPacks : IUpdaterBase
{
    [SerializeField] private TMP_Dropdown  dropdownMenu;
    private List<string> availableSeedPacks = new List<string>();

    public void Awake()
    {
        availableSeedPacks.Clear();
    }
    public override void SharedUpdate()
    {
        if(InventoryManager.recentChangeOccured)
        {
            InventoryManager.recentChangeOccured = false;
            dropdownMenu.ClearOptions();
            availableSeedPacks.Clear();
            foreach (var item in InventoryManager.inventory)
            {
             
                if (item.Key == "Watering Cans" || item.Key == "Resolvant")
                    continue;

                if (item.Value > 0)
                {

                    availableSeedPacks.Add(item.Key);

                }
            }
            dropdownMenu.RefreshShownValue();
            dropdownMenu.AddOptions(availableSeedPacks);
        }
    }
    
}
