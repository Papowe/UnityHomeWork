using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 50;
    private float speedBullet = 10f;
    private float lifeTime = 5f;

    private Rigidbody bulletRigitBody;

    public int Damage { get => damage; set => damage = value; }

    private void Start()
    {
        Destroy(gameObject, lifeTime);

        bulletRigitBody = gameObject.GetComponent<Rigidbody>();

        Vector3 impulce = transform.forward * bulletRigitBody.mass * speedBullet;

        bulletRigitBody.AddForce(impulce, ForceMode.Impulse);
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>()?.GetDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
