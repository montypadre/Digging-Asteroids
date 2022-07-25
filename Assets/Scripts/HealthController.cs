using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health = 100;
    private int currentHealth = 0;
    public GameController gameController;

    void Start()
    {
        currentHealth = health;
    }

	public void DealDamage(int damage)
	{
        Debug.Log("Dealing Damage");
        currentHealth = currentHealth - damage;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
		{
            Destroy(gameObject, 0.5f);
		}
	}
}
