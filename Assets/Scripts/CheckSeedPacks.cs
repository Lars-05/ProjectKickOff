using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSeedPacks : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown  dropdownMenu;
    private List<string> availableSeedPacks = new List<string>();
    private void Awake()
    {
        dropdownMenu.options.Clear();
        availableSeedPacks.Clear();
        foreach (var item in InventoryManager.inventory)
        {
            Debug.Log(item.Key);
            Debug.Log(item.Value);
            if (item.Key == "Watering Cans" || item.Key == "Resolvant")
                continue;

            if (item.Value > 0)
            {
               
                availableSeedPacks.Add(item.Key);

            }
        }

        dropdownMenu.AddOptions(availableSeedPacks);
    }
}
