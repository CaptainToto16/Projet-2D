using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth;
    public Slider HealthBar;

    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();

        if (HealthBar != null)
        {
            HealthBar.maxValue = maxHealth;
            HealthBar.value = currentHealth;
        }
        else
        {
            Debug.LogWarning("HealthBar is null!");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " has " + amount + " damage. Current HP: " + currentHealth);

        if (HealthBar != null)
        {
            HealthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()

    {
        if (animator != null)
        {
            
            animator.SetTrigger("BlueDeath");
        }
        else
        {
            Debug.LogWarning("Animator is null!");
        }

        
        if (TryGetComponent<EnemyPatrol>(out var patrol))
            patrol.enabled = false;

        if (TryGetComponent<Rigidbody2D>(out var rb))
            rb.linearVelocity = Vector2.zero; 
        rb.simulated = false; 

        foreach (var collider in GetComponents<Collider2D>())
            collider.enabled = false;

        Destroy(gameObject, 1.3f);
    }
}