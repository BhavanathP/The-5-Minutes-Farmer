using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FiveMinutesFarmer.UI
{
    public class ShopManager : Singleton<ShopManager>
    {
        [SerializeField] private GameObject shopPanel;
        [SerializeField] private TMP_Text shopTitleText;
        [SerializeField] private Transform shopContentParent;
        [SerializeField] private GameObject shopItemPrefab;
        [SerializeField] private UnLockSystem unlockSystem;

        private void TryBuyCrop(CropData crop)
        {
            AudioManager.Instance.PlaySFX(AudioType.UI_Click);
            if (CurrencyManager.Instance.SpendCurrency(crop.buyPrice))
            {
                InventoryManager.Instance.AddCrop(crop.cropType, 1);
                shopTitleText.SetText("Purchased " + crop.cropType.ToString());
                //unlockSystem.UnlockCrop(crop.cropType);
                Debug.Log($"{crop.cropType} purchased!");
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }

        public void ToggleShop()
        {
            if (shopPanel.activeSelf)
                CloseShop();
            else
                OpenShop();
        }

        public void OpenShop()
        {
            shopTitleText.SetText("Shop Menu");
            InputManager.Instance.controls.Player.Pause.Disable();
            InputManager.Instance.controls.Player.Move.Disable();
            InputManager.Instance.OnBack += CloseShop;
            PopulateShop();
            shopPanel.SetActive(true);
        }

        public void CloseShop()
        {
            InputManager.Instance.OnBack -= CloseShop;
            shopPanel.SetActive(false);
            InputManager.Instance.controls.Player.Pause.Enable();
            InputManager.Instance.controls.Player.Move.Enable();
        }

        private void PopulateShop()
        {
            foreach (Transform child in shopContentParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var crop in CropsManager.Instance.GetAllCrops())
            {
                if (!unlockSystem.IsCropUnlocked(crop.cropType))
                {
                    var itemGO = Instantiate(shopItemPrefab, shopContentParent);
                    var shopItem = itemGO.GetComponent<ShopItem>();
                    shopItem.SetItem(crop.cropType.ToString(), crop.buyPrice);
                    shopItem.SetButtonAction(() => TryBuyCrop(crop));
                }
            }
        }
    }
}