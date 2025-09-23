using TMPro;
using UnityEngine;

public class UIManager : IUpdaterBase
{
    [SerializeField] private TextMeshProUGUI resolvantAmountField;
    [SerializeField] private TextMeshProUGUI wateringCansField;

    public override void SharedUpdate()
    {
        resolvantAmountField.text = InventoryManager.GetItemCount("Resolvant").ToString();
        wateringCansField.text = InventoryManager.GetItemCount("Watering Cans").ToString();
    }
    private void Awake()
    {
        InventoryManager.RecieveData(); 
    }
}
