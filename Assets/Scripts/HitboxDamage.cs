using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
	    EnemyHealth enemy = other.GetComponent<EnemyHealth>();
	    if (enemy != null)
	    {
		    enemy.TakeDamage(damage);
	    }
    }
}