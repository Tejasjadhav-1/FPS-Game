using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] int dammageAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Something entered: " + other.name);
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player detected");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dammageAmount);
            }
        }
    }
}
