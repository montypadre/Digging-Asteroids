using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject explosion;
	public JawsBehavior jaws;
	bool exploding = false;
	public GameController gameController;

	private void Start()
	{
		jaws = GameObject.FindWithTag("Jaws").GetComponent<JawsBehavior>();
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		StartCoroutine(Countdown());
	}

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5f);
		if (!exploding)
		{
			exploding = true;
			GameObject explosionGo = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));

			Destroy(gameObject, 0.5f);
			Destroy(explosionGo, 1f);

			if (jaws.isGrabbing)
			{
				gameController.PlayerDies();
			}
		}
	}
}
