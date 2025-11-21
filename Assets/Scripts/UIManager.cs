using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages all UI elements including health, ammo, and crosshair
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Health UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Ammo UI")]
    [SerializeField] private TextMeshProUGUI ammoText;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Initialize crosshair
        if (crosshair != null)
        {
            crosshair.enabled = true;
        }
    }

    public void UpdateHealth(float healthPercentage)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = healthPercentage;
        }

        if (healthText != null)
        {
            healthText.text = Mathf.Ceil(healthPercentage * 100).ToString();
        }
    }

    public void UpdateAmmo(int currentAmmo, int reserveAmmo)
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo + " / " + reserveAmmo;
        }
    }

    public void ShowGameOver(string message = "Game Over")
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverText != null)
        {
            gameOverText.text = message;
        }

        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetCrosshairActive(bool active)
    {
        if (crosshair != null)
        {
            crosshair.enabled = active;
        }
    }
}
