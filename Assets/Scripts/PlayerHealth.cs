using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float MaxHealth;
    public Image healthBar;
    public Animator animator;
    public PlayerController playerController;

    void Start()
    {
        MaxHealth = health;
    }


    void Update()
    {

        if (health <= 0)
        {
            Die();
        }

        healthBar.fillAmount = Math.Clamp(health / MaxHealth, 0, 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("TakeDamage");
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Die()
    {
       playerController.enabled = false;

        animator.SetTrigger("Die");
        StartCoroutine(WaitAndRestart());
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(3f); 
        RestartLevel();
    }
}




