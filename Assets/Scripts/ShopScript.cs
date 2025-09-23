using UnityEngine;

public class ShopScript : MonoBehaviour
{
   public void BasicSeedPackClicked()
   {
      InventoryManager.AddItemToInventory("Basic Seed Pack", 1);
   }
   
   public void FruitSeedPackClicked()
   {
      if (CanAfford(10))
      {
         GetItem("Basic Seed Pack", 1);
      }


   }
   
   public void SpringSeedPackClicked()
   {
      if (CanAfford(10))
      {
         GetItem("Fruit Seed Pack", 1);
      }
   }
   
   public void SummerSeedPackClicked()
   {
      if (CanAfford(15))
      {
         GetItem("Spring Seed Pack", 1);
      }
   }
   
   public void AutumnSeedPackClicked()
   {
      if (CanAfford(15))
      {
         GetItem("Summer Seed Pack", 1);
      }
   }
   
   public void WinterSeedPackClicked()
   {
      if (CanAfford(15))
      {
         GetItem("Autumn Seed Pack", 1);
      }
   }
   
   public void WateringCanClicked()
   {
      if (CanAfford(15))
      {
         GetItem("Watering Cans", 2);
      }
   }

   private bool CanAfford(int amount)
   {
      if (InventoryManager.GetItemCount("Resolvant") >= amount)
      {
         InventoryManager.RemoveItemFromInventory("Resolvant", amount);
         return true;
      }
      return false;
   }
   
   private void GetItem(string item, int amount)
   {
      InventoryManager.RemoveItemFromInventory("item", amount);
   }
   
}
