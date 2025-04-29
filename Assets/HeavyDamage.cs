using System;
using JetBrains.Annotations;
using UnityEngine;

public class HeavyDamage : MonoBehaviour
{
	public int damage = 5;

	private void OnTriggerEnter2D(Collider2D other)
	{
		EnemyHealth enemy = other.GetComponent<EnemyHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}

	}
}



//EnemyHealth enemy = other.GetComponent<EnemyHealth>();
	    //if (enemy != null)
	    
		    //enemy.TakeDamage(damage);
	    
	    

