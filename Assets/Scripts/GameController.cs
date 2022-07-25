using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public Vector3 screenCenter;
	public GameObject bigRock;
	public GameObject rockSpawner;

	public float spawnTime = 1f;

	// public Vector3 screenCenter;

	bool isPlayerAlive;
	float time = 0.0f;

	void Start()
	{
		Physics.gravity = new Vector3(0, -1.0F, 0);

		// Instantiating player
		player = Instantiate(player, new Vector3(0, -3, 0), Quaternion.Euler(0, 0, 0));
		StartCoroutine(Delay());
	}

	void Spawn()
	{
		Instantiate(bigRock, new Vector3(Random.Range(-4.5f, 4.5f), rockSpawner.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
	}

	IEnumerator Delay()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnTime);
			Spawn();
		}

	}
}
