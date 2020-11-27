using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(health);
            Destroy(gameObject);
        }
    }
}
