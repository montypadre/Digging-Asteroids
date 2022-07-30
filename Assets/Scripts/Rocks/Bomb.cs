using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject explosion;
	bool exploding = false;
	public GameController controller;

	private void Start()
	{
		controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		StartCoroutine(Countdown());
	}

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5f);
		if (!exploding)
		{
			exploding = true;
			GameObject explosionGo = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));

			controller.PlayerDies(); 
			Destroy(gameObject, 0.5f);
			Destroy(explosionGo, 1f);
		}
	}
}
