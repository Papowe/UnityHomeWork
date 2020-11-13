using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int damage = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().GetDamage(damage);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 15f);
    }
}
