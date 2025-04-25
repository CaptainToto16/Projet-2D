using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public float speed = 2f;
	public float patrolDistance = 3f;

	private Vector2 startPoint;
	private bool goingRight = true;

	void Start()
	{
		startPoint = transform.position;
	}

	void Update()
	{
		float move = speed * Time.deltaTime;

		if (goingRight)
		{
			transform.Translate(Vector2.right * move);
			if (Vector2.Distance(startPoint, transform.position) >= patrolDistance)
			{
				goingRight = false;
				Flip();
			}
		}
		else
		{
			transform.Translate(Vector2.left * move);
			if (Vector2.Distance(startPoint, transform.position) >= patrolDistance)
			{
				goingRight = true;
				Flip();
			}
		}
	}

	void Flip()
	{
		
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}