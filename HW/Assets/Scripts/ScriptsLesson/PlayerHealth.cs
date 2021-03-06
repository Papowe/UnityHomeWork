﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 1000;
    [SerializeField] private AudioSource stopMusic;
    [SerializeField] private AudioSource loseMusic;


    public int Health
    {
        get => health; 
        set
        {
            health = value;
            HealthBar healthBar = GameObject.FindObjectOfType<HealthBar>();
            healthBar.ViewHealts();
        }
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        if (health <= 0)
        {
            Die();
        }        
    }

    public void AddHealth(int health)
    {
        Health += health;
    }

    private void Die()
    {
        //Time.timeScale = 0;
        stopMusic.Stop();
        loseMusic.Play();
        gameObject.SetActive(false);
        MyUIController.instance.GameStatus("YOU LOSE");
        
    }

}
