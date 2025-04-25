using System;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
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