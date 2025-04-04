using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float MaxHealth;
    public Image healthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()


    {
        MaxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Math.Clamp(health / MaxHealth, 0, 1);
    }
}

      
    
