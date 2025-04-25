using UnityEngine;

public class Respawn : MonoBehaviour
{
	public GameObject player;
	public Transform respawnPoint;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if ( collision.CompareTag("FalllDetector"))
		{
			player.transform.position = new Vector2(-1, 0);
		}

	}
}

