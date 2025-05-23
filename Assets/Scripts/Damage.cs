using Unity.Cinemachine;
using UnityEngine;

public class Damage : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public float damage;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (other.gameObject.CompareTag("Player"))
			{
				PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
				if (playerHealth != null)
				{
					playerHealth.TakeDamage(damage);
				}
			}
		}
	}
}
    

