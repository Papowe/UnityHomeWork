using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 50;
    private float speedBullet = 10f;

    public int Damage { get => damage; set => damage = value; }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.GetComponent<Enemy>()?.GetDamage(damage);
            Destroy(gameObject);
        }        
    }
}
