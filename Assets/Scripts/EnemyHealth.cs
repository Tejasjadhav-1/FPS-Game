using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 300;
    [SerializeField] int currentHealth;

    bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int ammount)
    {
        if(isDead)
        {
            return;
        }

        currentHealth-=ammount;

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
}
