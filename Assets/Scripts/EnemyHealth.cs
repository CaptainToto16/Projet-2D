using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
	public int maxHealth = 3;
	private int currentHealth;

	public Slider HealthBar;

	private void Start()
	{
		currentHealth = maxHealth;
		if (HealthBar != null)
		{
			HealthBar.maxValue = maxHealth;
			HealthBar.value = currentHealth;
		}
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		Debug.Log(gameObject.name + " has " + amount + " damage" + currentHealth);
		
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
		Debug.Log(gameObject.name + "is dead");
		
		Destroy(gameObject);
	}
}
	
    