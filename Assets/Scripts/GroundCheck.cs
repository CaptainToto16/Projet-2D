using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	public class GroundChecker : MonoBehaviour
	{

		public bool IsGrounded;
		public LayerMask groundLayer;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (((1 << other.gameObject.layer) & groundLayer) != 0)
				IsGrounded = true;
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (((1 << other.gameObject.layer) & groundLayer) != 0)
				IsGrounded = false;
		}
	}
}