using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int maxHealth = 3;
	private int currentHealth;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		Debug.Log(gameObject.name + " has " + amount + " damage" + currentHealth);

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
	
    