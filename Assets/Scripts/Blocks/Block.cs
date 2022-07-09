using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public int health = 100;
	public float damageCooldown = 0.5f;
	public float currentTime;
	public int currentHealth = 0;

	void Start()
	{
		currentHealth = health;
	}

	public void DealDamage(int damage)
	{
		Debug.Log(currentHealth);
		currentHealth = currentHealth - damage;

		if (currentHealth < 100 && currentHealth >= 50)
		{
			// TODO: Instantiate block with first drill hit damage
		}
		else if (currentHealth < 50 && currentHealth > 0)
		{
			// TODO: Instantiate block with second drill hit damage
		}
		else
		{
			// Instantiate destroyed block
			Destroy(gameObject, 0.5f);
		}
	}
}
