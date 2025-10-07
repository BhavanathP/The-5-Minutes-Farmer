using TMPro;
using UnityEngine;

namespace FiveMinutesFarmer.UI
{
    public class InteractionMenu : MonoBehaviour
    {
        public static InteractionMenu Instance;
        public GameObject interactMenuPanel;
        public TMP_Text titleText;
        public Transform itemsParent;
        public MenuItem menuItemPrefab;
        public TileController currentTile;
        public bool isWaterMenu = false;
        public GameObject fetchWaterVFX;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void Show()
        {
            InputManager.Instance.controls.Player.Pause.Disable();
            InputManager.Instance.controls.Player.Move.Disable();
            InputManager.Instance.OnBack += Hide;
            PopulateMenu();
            interactMenuPanel.SetActive(true);
        }
        public void Hide()
        {
            currentTile = null;
            InputManager.Instance.OnBack -= Hide;
            InputManager.Instance.controls.Player.Pause.Enable();
            InputManager.Instance.controls.Player.Move.Enable();
            interactMenuPanel.SetActive(false);
        }


        private void PopulateMenu()
        {
            foreach (Transform child in itemsParent)
            {
                Destroy(child.gameObject);
            }
            if (currentTile != null)
            {
                switch (currentTile.GetCurrentState())
                {
                    case EmptyState:
                        titleText.SetText("Select Crop to Plant");
                        PopulateCropMenu();
                        break;
                    case PlantedState:
                        titleText.SetText("Water Crop");
                        PopulateWaterMenu();
                        break;
                    case HarvestableState:
                        titleText.SetText("Harvest Crop");
                        PopulateHarvestMenu();
                        break;
                    default:
                        titleText.SetText("its Growing");
                        break;
                }
            }
            if (isWaterMenu)
            {
                bool needsWater = InventoryManager.Instance.WaterCount <= 10;
                titleText.SetText(needsWater ? "Collect Water" : "Water already full");
                var menuItem = Instantiate(menuItemPrefab, itemsParent);
                menuItem.SetItem($"Water", 3);
                if (needsWater)
                {
                    menuItem.SetOnClickAction(() =>
                    {
                        AudioManager.Instance.PlaySFX(AudioType.WaterPour);
                        fetchWaterVFX.SetActive(true);
                        Invoke(nameof(DisableWaterVFX), 0.5f);
                        InventoryManager.Instance.FetchWater(3);
                        Hide();
                    });
                }
            }
        }
        private void DisableWaterVFX()
        {
            fetchWaterVFX.SetActive(false);
        }

        private void PopulateCropMenu()
        {
            var crops = InventoryManager.Instance.GetCropDetails();
            if (crops.Count > 0)
            {
                titleText.SetText("Select Crop to Plant");
                foreach (var crop in crops)
                {
                    if (crop.count <= 0) continue;
                    var _cropData = CropsManager.Instance.GetCropDetails(crop.cropType);
                    var menuItem = Instantiate(menuItemPrefab, itemsParent);
                    menuItem.SetItem(crop.cropType.ToString(), crop.count);
                    menuItem.SetOnClickAction(() =>
                    {
                        AudioManager.Instance.PlaySFX(AudioType.UI_Click);
                        InventoryManager.Instance.UseCrop(crop.cropType);
                        currentTile.SetCrop(_cropData);
                        currentTile.TransitionToState(currentTile.plantedState);
                        Hide();
                    });
                }
            }
            else
            {
                titleText.SetText("No Crops Available");
            }
        }
        private void PopulateHarvestMenu()
        {
            var menuItem = Instantiate(menuItemPrefab, itemsParent);
            menuItem.SetItem(currentTile.CurrentCrop.cropType.ToString(), currentTile.CurrentCrop.sellValue);
            menuItem.SetOnClickAction(() =>
            {
                AudioManager.Instance.PlaySFX(AudioType.CropPicking);
                currentTile.TransitionToState(currentTile.emptyState);
                CurrencyManager.Instance.AddCurrency(currentTile.CurrentCrop.sellValue);
                ScoreManager.Instance.AddScore(currentTile.CurrentCrop.value);
                currentTile.ResetTile();
                currentTile.TransitionToState(currentTile.emptyState);
                Hide();
                Invoke(nameof(CoinSound), 1f);
            });
        }

        private void CoinSound()
        {
            AudioManager.Instance.PlaySFX(AudioType.CoinGained);
        }

        private void PopulateWaterMenu()
        {
            var menuItem = Instantiate(menuItemPrefab, itemsParent);
            menuItem.SetItem($"Water", InventoryManager.Instance.WaterCount);
            if (InventoryManager.Instance.WaterCount > 0)
            {
                menuItem.SetOnClickAction(() =>
                {
                    AudioManager.Instance.PlaySFX(AudioType.WaterPour);
                    InventoryManager.Instance.UseWater(1);
                    currentTile.TransitionToState(currentTile.growingState);
                    Hide();
                });
            }
        }
    }
}