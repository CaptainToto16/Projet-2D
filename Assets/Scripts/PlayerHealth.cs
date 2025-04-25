using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        if (health <= 0)
        {
            Die();
        }

        healthBar.fillAmount = Math.Clamp(health / MaxHealth, 0, 1);
    }
    

    public void Die()
    {
        Invoke("RestartLevel",0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}



    
