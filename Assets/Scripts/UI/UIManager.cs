using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiveMinutesFarmer.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("UI References")]
        [SerializeField] private GameObject player;
        [SerializeField] private StartPanel startPanel;
        [SerializeField] private InteractionMenu interactionMenu;
        [SerializeField] private GameplayHUD gameplayHUD;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private GameOverUI gameOverUI;
        [SerializeField] private InventoryMenu inventoryMenu;
        public GameTimer gameTimer;

        private void Start()
        {
            interactionMenu.Hide();
            gameplayHUD.Hide();
            pauseMenu.Hide();
            gameOverUI.Hide();

            startPanel.Show();
            startPanel.startButton.onClick.AddListener(StartGame);
        }

        public void StartGame()
        {
            player.SetActive(true);
            AudioManager.Instance.PlaySFX(AudioType.UI_Click);
            startPanel.Hide();
            gameplayHUD.Show();
            // Subscribe to ScoreManager
            ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
            InputManager.Instance.OnPause += pauseMenu.TogglePauseMenu;
            CurrencyManager.Instance.OnCurrencyChanged += UpdateCoinText;

            // Get TimerManager & subscribe
            gameTimer = TimerManager.Instance.StartTimer(300f); // 5 min

            gameTimer.OnTick += UpdateTimerUI;
            gameTimer.OnCompleted += ShowGameOver;
        }

        private void UpdateScoreUI(int score)
        {
            gameplayHUD.UpdateScore(score);
        }
        public void UpdateCoinText(int coins)
        {
            gameplayHUD.UpdateCoins(coins);
        }

        private void UpdateTimerUI(float remaining)
        {
            int minutes = Mathf.FloorToInt(remaining / 60);
            int seconds = Mathf.FloorToInt(remaining % 60);
            gameplayHUD.UpdateTimer(minutes, seconds);
        }

        private void ShowGameOver()
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
            InputManager.Instance.OnPause -= pauseMenu.TogglePauseMenu;
            pauseMenu.ResumeGame();

            gameOverUI?.Show(ScoreManager.Instance.GetScore(), CurrencyManager.Instance.GetEarnedCurrency());
        }

        public void ToggleInventory()
        {
            if (inventoryMenu.inventoryPanel.activeSelf)
                inventoryMenu.Hide();
            else
                inventoryMenu.Show();
        }

        public void ToggleInteractionMenu(TileController tile = null, bool isWaterMenu = false)
        {
            if (interactionMenu.interactMenuPanel.activeSelf)
                interactionMenu.Hide();
            else
            {
                interactionMenu.titleText.SetText(tile != null ? "Plant Menu" : "Interact");
                interactionMenu.currentTile = tile;
                interactionMenu.isWaterMenu = isWaterMenu;
                interactionMenu.Show();
            }
        }
    }
}