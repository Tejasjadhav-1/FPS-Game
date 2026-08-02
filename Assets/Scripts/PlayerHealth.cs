using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 50;

    [SerializeField] GameObject youDiedPanel;

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        PrintHealth();
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        PrintHealth();
        if (currentHealth == 0)
        {
            Died();
        }
    }

    public void Died()
    {
        youDiedPanel.SetActive(true);
    }
    private void PrintHealth()
    {
        Debug.Log($"Health: {currentHealth}/{maxHealth}");
    }
}
