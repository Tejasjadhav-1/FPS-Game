using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 300;
    [SerializeField] int currentHealth;

    [SerializeField] Slider healthSlider;

    bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int ammount)
    {
        if(isDead)
        {
            return;
        }

        currentHealth-=ammount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        GameObject.Destroy(gameObject);
    }

    private void UpdateHealthUI()
    {
        float fraction = (float)currentHealth / maxHealth;

        healthSlider.value = fraction;
    }
}
