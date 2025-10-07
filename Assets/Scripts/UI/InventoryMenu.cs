using TMPro;
using UnityEngine;

namespace FiveMinutesFarmer.UI
{
    public class InventoryMenu : MonoBehaviour
    {
        public GameObject inventoryPanel;
        [SerializeField] private InventoryItem itemPrefab;
        [SerializeField] private Transform contentParent;

        public Sprite waterIcon;
        public Sprite carrotIcon;
        public Sprite cornIcon;
        public Sprite coinIcon;

        public void Show()
        {
            InputManager.Instance.controls.Player.Pause.Disable();
            InputManager.Instance.controls.Player.Move.Disable();
            InputManager.Instance.OnBack += Hide;
            PopulateInventory();
            inventoryPanel.SetActive(true);
        }
        public void Hide()
        {
            InputManager.Instance.OnBack -= Hide;
            InputManager.Instance.controls.Player.Pause.Enable();
            InputManager.Instance.controls.Player.Move.Enable();
            inventoryPanel.SetActive(false);
        }


        public Sprite GetIcon(string itemName)
        {
            switch (itemName)
            {
                case "Water":
                    return waterIcon;
                case "Carrot":
                    return carrotIcon;
                case "Corn":
                    return cornIcon;
                case "Coin":
                    return coinIcon;
                default:
                    return null;
            }
        }

        private void PopulateInventory()
        {
            foreach (Transform child in contentParent)
            {
                Destroy(child.gameObject);
            }

            //Water
            var itemGO = Instantiate(itemPrefab, contentParent);
            var icon = GetIcon("Water");
            itemGO.SetItem(icon, "Water", InventoryManager.Instance.WaterCount);

            //Coin
            itemGO = Instantiate(itemPrefab, contentParent);
            icon = GetIcon("Coin");
            itemGO.SetItem(icon, "Coin", CurrencyManager.Instance.GetAllCurrency());

            //Crops
            foreach (var crop in InventoryManager.Instance.GetCropDetails())
            {
                if(crop.count <= 0) continue;
                itemGO = Instantiate(itemPrefab, contentParent);
                icon = GetIcon(crop.cropType.ToString());
                itemGO.SetItem(icon, crop.cropType.ToString(), crop.count);
            }
        }
    }
}