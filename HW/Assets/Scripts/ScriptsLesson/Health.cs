using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private float speedRotation = 45f;

    private void Update()
    {
        AnimationHealth(speedRotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(health);
            Destroy(gameObject);
        }
    }

    private void AnimationHealth(float speedRotation)
    {
        transform.rotation *= Quaternion.Euler(0, speedRotation * Time.deltaTime, 0);
    }
}
