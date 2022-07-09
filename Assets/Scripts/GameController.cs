using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public GameObject player;
	public GameObject[] grid; /*= new GameObject[7];*/
    public GameObject[] blocks;
    private BoxCollider boxCollider;
    private Rigidbody rigidBody;
    

    public float maxRange = 10f;
    public float minRange = 5f;
    private float height;
    private float speed = -1f;
	public float spawnTime = 1f;
    //public float maxScale = 10f;
    //public float minScale = 5f;
    //public float spawnInterval = 3f;

    // public Vector3 screenCenter;

    bool isPlayerAlive;
    float time = 0.0f;
    //float minY;
    //float maxY;
    //float minX;
    //float maxX;

    void Start()
    {
        // Instantiating player
        player = Instantiate(player, new Vector3(0, -4, 10.01f), Quaternion.Euler(0, 0, 0));

		StartCoroutine(Delay());
		//screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

		//width = grid.Length;

		// Make grid
		//      Vector3 start = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.65f, 0f) + new Vector3(0f, 0f, 10f));

		//      for (int i = 0; i < grid.GetLength(0); i++)
		//{
		//          for (int j = 0; j < grid.GetLength(1); j++)
		//	{
		//              grid[i,j] = Instantiate(blocks[Random.Range(0, blocks.Length)], start + new Vector3(i, j, 0f), Quaternion.Euler(0, 0, 0));
		//  //            boxColliders = blocks[j].gameObject.GetComponents<BoxCollider>();
		//  //            rigidBodies = blocks[j].gameObject.GetComponents<Rigidbody>();

		//  //            height = boxColliders.Length;
		//		//rigidBodies[j].velocity = new Vector3(0, speed, 0);
		//          }
		//}
		//boxColliders = blocks[j].gameObject.GetComponent<BoxCollider>();
		//rigidBodies[i, j] = grid[i, j].gameObject.GetComponent<Rigidbody>();

		//height = boxColliders[i, j].size.y;
		//rigidBodies[i, j].velocity = new Vector3(0, speed, 0);
	}

	void Update()
	{
		Reposition();
		//Spawn();
	}

	void Spawn()
	{
		//Debug.Log("Spawn");
		// Make grid
		Vector3 start = Camera.main.ViewportToWorldPoint(new Vector3(.24f, 1.1f, 0f) + new Vector3(0f, 0f, 10f));

		for (int i = 0; i < grid.Length; i++)
		{
			if (CheckBounds2D(blocks[i].transform.position, new Vector2(0,0), 0))
			{
				//Debug.Log("Checked Bounds");
				grid[i] = Instantiate(blocks[Random.Range(0, blocks.Length)], start + new Vector3(i, 0f, 0f), Quaternion.Euler(0, 0, 0));
				boxCollider = grid[i].GetComponent<BoxCollider>();
				rigidBody = grid[i].GetComponent<Rigidbody>();

				height = boxCollider.size.y;
				rigidBody.velocity = new Vector3(0, speed, 0);
			}
			//grid[i] = Instantiate(blocks[Random.Range(0, blocks.Length)], start + new Vector3(i, 0f, 0f), Quaternion.Euler(0, 0, 0));
			//boxCollider = grid[i].GetComponent<BoxCollider>();
			//rigidBody = grid[i].GetComponent<Rigidbody>();

			//height = boxCollider.size.y;
			//rigidBody.velocity = new Vector3(0, speed, 0);
		}
	}

	void Reposition()
	{
		Vector3 vector = new Vector3(0, height * 2f, 0);
		for (int i = 0; i < blocks.Length; i++)
		{
			transform.position = (Vector3)transform.position + vector;
		}
	}

	IEnumerator Delay()
	{
		while(true)
		{
			yield return new WaitForSeconds(spawnTime);
			Spawn();
		}
		
	}

	public static bool CheckBounds2D(Vector2 position, Vector2 boundsSize, int layerMask)
	{
		Bounds boxBounds = new Bounds(position, boundsSize);

		float sqrHalfBoxSize = boxBounds.extents.sqrMagnitude;
		float overlapingCircleRadius = Mathf.Sqrt(sqrHalfBoxSize + sqrHalfBoxSize);

		/* Hoping I have the previous calculation right, move on to finding the nearby colliders */
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, overlapingCircleRadius, layerMask);
		foreach (Collider2D otherCollider in hitColliders)
		{
			//now we ask each of thoose gentle colliders if they sens something is within their bounds
			if (otherCollider.bounds.Intersects(boxBounds))
				return (false);
		}
		return (true);
	}
}
