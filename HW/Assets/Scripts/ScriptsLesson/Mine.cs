using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int damage = 100;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float power = 10f;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {            
            MinExplosion();
            Destroy(gameObject);
        }
    }

    private void MinExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            hit.GetComponent<Enemy>()?.GetDamage(damage);
            hit.GetComponent<PlayerHealth>()?.GetDamage(damage);

            if (rb != null)
            {
                Vector3 dirrection = (rb.position - transform.position).normalized;
                rb.AddForce(dirrection * power, ForceMode.Impulse);
            }
        }
    }   
}
