using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private GameObject healthEffect;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(health);
            Instantiate(healthEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
