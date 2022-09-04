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
	public GameObject medRock;
	public GameObject rockSpawner;
	public GameObject gameOverPanel;

	public float spawnTime = 1f;
	public float gameOverDelay = 1f;
	public float gameOverExpire = 10f;

	// public Vector3 screenCenter;

	bool isPlayerAlive = true;
	float time = 0.0f;

	void Start()
	{
		Physics.gravity = new Vector3(0, -1.0F, 0);

		// Instantiating player
		player = Instantiate(player, new Vector3(0, -3, 0), Quaternion.Euler(0, 0, 0));
		//StartCoroutine(Delay());
		gameOverPanel.SetActive(false);
	}

	private void Update()
	{
		if (isPlayerAlive)
		{
			time += Time.deltaTime;

			if (time >= spawnTime)
			{
				time = time - spawnTime;

				Spawn();
			}
		}
		else
		{
			if (time < gameOverDelay)
			{
				time = time + Time.deltaTime;
			}
			else if (Input.anyKey || time > gameOverExpire)
			{
				//SceneManager.LoadScene("MainMenuScene");
			}
		}
	}

	void Spawn()
	{
		Instantiate(medRock, new Vector3(Random.Range(-4.5f, 4.5f), rockSpawner.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
	}

	//IEnumerator Delay()
	//{
	//	while (true)
	//	{
	//		yield return new WaitForSeconds(spawnTime);
	//		Spawn();
	//	}

	//}

	public void PlayerDies()
	{
		Destroy(player);
		isPlayerAlive = false;
		gameOverPanel.SetActive(true);
		//gamePanel.SetActive(false);
		time = 0.0f;
	}
}
