using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsBehavior : MonoBehaviour
{
	//public int damage = 40;
	private bool isEnemy = false;
	public bool isGrabbing = false;
	public ParticleSystem chompParticle;
	public MedRock medRock;
	private Collider col;
	private GameObject currentObj;

	private void Update()
	{
		Debug.Log(currentObj);
		if (col != null)
		{
			if (Input.GetMouseButtonDown(0) && col.CompareTag("Rock"))
			{
				col.gameObject.GetComponent<MedRock>().Chomp();
				Instantiate(chompParticle, transform.position, transform.rotation);
			}
			if (Input.GetMouseButtonDown(1) && !col.CompareTag("Rock"))
			{
				currentObj = col.gameObject;
				gameObject.GetComponent<GrabObjects>().GrabObject(col.gameObject);
			}
			if (Input.GetMouseButtonUp(1) )
			{
				gameObject.GetComponent<GrabObjects>().ReleaseObject(currentObj);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		col = other;
	}

	//private void Update()
	//{
	//	if (isEnemy && enemy != null)
	//	{
	//		if (enemy.gameObject.CompareTag("Rock"))
	//		{
	//			if (Input.GetMouseButtonDown(0))
	//			{
	//				enemy.gameObject.GetComponent<MedRock>().Chomp();
	//				Instantiate(chompParticle, transform.position, transform.rotation);
	//			}
	//			//else if (Input.GetMouseButtonUp(0))
	//			//{
	//			//	//if (enemy.gameObject.CompareTag("Gem") || enemy.gameObject.CompareTag("Bomb"))
	//			//	//{
	//			//	//	isGrabbing = false;
	//			//	//	gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
	//			//	//}
	//			//	//Debug.Log(enemy);
	//			//	switch (enemy.gameObject.name)
	//			//	{
	//			//		case "Bomb(Clone)":
	//			//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
	//			//			break;
	//			//		case "purple(Clone)":
	//			//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
	//			//			break;
	//			//		case "sapphire(Clone)":
	//			//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
	//			//			break;
	//			//		case "emerald(Clone)":
	//			//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
	//			//			break;
	//			//		case "star(Clone)":
	//			//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
	//			//			break;
	//			//		default:
	//			//			break;
	//			//	}
	//			//}
	//			//	{
	//			//if (enemy.gameObject.CompareTag("Rock"))
	//			//{
	//			//	enemy.gameObject.GetComponent<MedRock>().Chomp();
	//			//	Instantiate(chompParticle, transform.position, transform.rotation);
	//			//}
	//			//else if (enemy.gameObject.CompareTag("Gem") || enemy.gameObject.CompareTag("Bomb"))
	//			//{
	//			//	Debug.Log(isGrabbing);
	//			//	isGrabbing = true;
	//			//	gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
	//			//}
	//			//	Debug.Log(enemy);
	//			//switch (enemy.gameObject.name)
	//			//{
	//			//	case "Med Rock(Clone)":
	//			//		enemy.gameObject.GetComponent<MedRock>().Chomp();
	//			//		Instantiate(chompParticle, transform.position, transform.rotation);
	//			//		break;
	//			//	case "Bomb(Clone)":
	//			//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
	//			//		break;
	//			//	case "purple(Clone)":
	//			//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
	//			//		break;
	//			//	case "sapphire(Clone)":
	//			//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
	//			//		break;
	//			//	case "emerald(Clone)":
	//			//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
	//			//		break;
	//			//	case "star(Clone)":
	//			//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
	//			//		break;
	//			//	default:
	//			//		break;
	//			//}
	//		}
	//	}
	//}

	//void OnTriggerEnter(Collider col)
	//{
	//	enemy = col;
	//	isEnemy = true;
	//}

	//void OnTriggerExit(Collider col)
	//{
	//	isEnemy = false;
	//}

	void OnTriggerStay(Collider col)
	{
		if (Input.GetMouseButtonDown(0) && col.CompareTag("Rock"))
		{
			col.gameObject.GetComponent<MedRock>().Chomp();
			Instantiate(chompParticle, transform.position, transform.rotation);
		}
		else if (Input.GetMouseButtonDown(1) && !col.CompareTag("Rock"))
		{
			gameObject.GetComponent<GrabObjects>().GrabObject(col.gameObject);
		}
		else if (Input.GetMouseButtonUp(1) && !col.CompareTag("Rock"))
		{
			gameObject.GetComponent<GrabObjects>().ReleaseObject(col.gameObject);
		}
	}
}
