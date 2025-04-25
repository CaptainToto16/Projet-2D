using UnityEngine;
using UnityEngine.Splines;

public class PlayerAttack : MonoBehaviour
{
	private Animator _animator;
	private bool isAttacking = false;
	public float attackCooldown = 0.5f;
	private float attackTimer = 0f;

	private PlayerController playerMovement;
	
	void Start()
	{
		playerMovement = GetComponent<PlayerController>();
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !isAttacking)
		{
			Attack();
		}

		
		if (isAttacking)
		{
			attackTimer += Time.deltaTime;

			if (attackTimer >= attackCooldown)
			{
				isAttacking = false;
				attackTimer = 0f;

				if (playerMovement != null)
					playerMovement.enabled = true;
			}
		}
	}
	void Attack()
	{
		isAttacking = true;

		if (_animator != null)
			_animator.SetTrigger("PlayerAttack");

		if (playerMovement != null)
			playerMovement.enabled = false;
	}
}

    
   