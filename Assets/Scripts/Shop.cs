using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown shopItemsDropdown;
    [SerializeField] private TextMeshProUGUI priceText;
    private Dictionary<string, int> shopCosts = new Dictionary<string, int>()
    {
        {"SpringSeedPack", 5},
        {"SummerSeedPack", 5},
        {"AutumnSeedPack", 5},
        {"WinterSeedPack", 5},
        {"FruitSeedPack", 5},
        {"BasicSeedPack", 5},
        {"Watering Can", 10}
    };
    
    //PalaceHolder
    [SerializeField]private int balance;
    [SerializeField]private int wateringCanCounter;
    private Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        { "SpringSeedPack", 0 },
        { "SummerSeedPack", 0 },
        { "AutumnSeedPack", 0 },
        { "WinterSeedPack", 0 },
        { "FruitSeedPack", 0 },
        { "BasicSeedPack", 0 },
        { "Watering Can", 0 }
    };
    
    private void Awake()
    {
        var shopItem = shopItemsDropdown.options[shopItemsDropdown.value].text;
        var price = shopCosts[shopItem];
        string display = "€" + price;
        priceText.text = display;
    }

    public void BuyItem()
    {
        var shopItem = shopItemsDropdown.options[shopItemsDropdown.value].text;
        if (balance > shopCosts[shopItem])
        {
            balance -= shopCosts[shopItem];
            inventory[shopItem] += 1;
        }
        else
        {
            Debug.Log("Not enough Money");
        }
        Debug.Log(inventory[shopItem]);
    }

    public void ItemSwitch()
    {
        var shopItem = shopItemsDropdown.options[shopItemsDropdown.value].text;
        var price = shopCosts[shopItem];
        string display = "€" + price;
        priceText.text = display;
    }
    
}
