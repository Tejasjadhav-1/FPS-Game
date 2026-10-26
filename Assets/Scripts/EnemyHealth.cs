using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 300;
    [SerializeField] int currentHealth;

    [SerializeField] float visibilityRange = 10f;

    [SerializeField] GameObject healthBarCanvas;

    [SerializeField] float damageFlashDuration = 3f;

    [SerializeField] Slider healthSlider;

    Transform player;

    float damageFlashTimer;

    bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance <= visibilityRange )
        {
            healthBarCanvas.SetActive(true);
        }
        else
        {
            damageFlashTimer -= Time.deltaTime;

            if( damageFlashTimer > 0  )
            {
                healthBarCanvas.SetActive(true);
            }
            else
            {
                healthBarCanvas.SetActive(false);
            }

        }
    }
    public void TakeDamage(int ammount)
    {
        if(isDead)
        {
            return;
        }

        damageFlashTimer = damageFlashDuration;
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
