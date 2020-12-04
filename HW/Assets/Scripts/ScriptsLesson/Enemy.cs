using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject dieEffect;
    private Vector3 offsetEffect = new Vector3(0, 0.5f, 0);

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(dieEffect, transform.position + offsetEffect, transform.rotation);
        Destroy(gameObject);
    }
}
