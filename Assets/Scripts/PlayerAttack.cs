using UnityEngine;
using UnityEngine.Splines;

public class PlayerAttack : MonoBehaviour
{
	private Animator _animator;
	private bool isAttacking = false;
	public float attackCooldown = 0.5f;
	private float attackTimer = 0f;

	public float heavyAttackCooldown = 10f;
	private float heavyAttackTimer = 0f;
	private bool isHeavyAttacking = false;

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

		if (Input.GetMouseButtonDown(1) && !isHeavyAttacking)
		{
			HeavyAttack();
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

		if (isHeavyAttacking)
		{
			heavyAttackTimer += Time.deltaTime;
			if (heavyAttackTimer >= heavyAttackCooldown)
			{
				isHeavyAttacking = false;
				heavyAttackTimer = 0f;
				if (playerMovement != null)
					playerMovement.enabled = true;
			}
		}
	}

	void Attack()
	{
		isAttacking = true;

		if (_animator != null)
			_animator.SetTrigger("Attack");

		if (playerMovement != null)
			playerMovement.enabled = false;
	}

	void HeavyAttack()
	{
		isHeavyAttacking = true;

		if (_animator != null)
			_animator.SetTrigger("HeavyAttack");

		if (playerMovement != null)
		playerMovement.enabled = false;
	}
}


    
   