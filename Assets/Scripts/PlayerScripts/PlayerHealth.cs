using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 50;
    
    [SerializeField] GameObject youDiedPanel;

    [SerializeField] TMP_Text healthText;

    private CameraLook cameraLook;
    private Playermovement playermovement;

    bool isDead = false;

    private void Awake()
    {
        cameraLook = GetComponent<CameraLook>();
        playermovement = GetComponent<Playermovement>();
    }

    private void Start()
    {
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth += amount;
        ClampHealth();
        UpdateHealthUI();
    }
    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;
        ClampHealth();
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ClampHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        youDiedPanel.SetActive(true);
        cameraLook.enabled = false;
        cameraLook.UnlockCursor();
        playermovement.enabled = false;
        
    }

    private void UpdateHealthUI()
    {
        healthText.text = $"Health: {currentHealth}/{maxHealth}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
