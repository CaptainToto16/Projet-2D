using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerAttack : MonoBehaviour
{
	private Animator _animator;
	private bool isAttacking = false;
	public float attackCooldown = 0.5f;
	private float attackTimer = 0f;

	public float heavyAttackCooldown = 1.3f;
	private float heavyAttackTimer = 0f;
	private bool isHeavyAttacking = false;

	private PlayerController playerMovement;
	[SerializeField] private float heavyAttackDuration = 1.2f;

	public ParticleSystem heavyAttackFlames;






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
			heavyAttackTimer -= Time.deltaTime;
			if (heavyAttackTimer <= 0f)
			{
				EndHeavyAttack();
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
		Debug.Log("heavy");
		heavyAttackTimer = heavyAttackDuration;
		isHeavyAttacking = true;
		heavyAttackTimer = heavyAttackDuration;

		if (_animator != null)
			_animator.SetTrigger("HeavyAttack");
		_animator.SetBool("isHeavyAttacking", true);

		if (playerMovement != null)
			playerMovement.enabled = false;

		if (heavyAttackFlames != null)
		{
			heavyAttackFlames.Play();
		}


	}
	public void EndHeavyAttack()
	{
		isHeavyAttacking = false;

		if (_animator != null)
			_animator.SetBool("isHeavyAttacking", false);

		if (playerMovement != null)
			playerMovement.enabled = true;
	}
}









   