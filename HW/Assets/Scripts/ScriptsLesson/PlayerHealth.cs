using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 1000;
    [SerializeField] InformationPanel informationPanel;

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int health)
    {
        this.health += health; 
    }

    private void Die()
    {       
        informationPanel.Information("YOU LOSE");
    }

}
