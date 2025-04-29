using UnityEngine;

public class HeavyHitbox : MonoBehaviour
{
	public GameObject attackHitbox;

	public void EnableHitbox()
	{
		attackHitbox.SetActive(true);
	}

	public void DisableHitbox()
	{
		attackHitbox.SetActive(false);
	}
}