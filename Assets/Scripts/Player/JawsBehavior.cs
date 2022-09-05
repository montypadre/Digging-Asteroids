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
	private Collider enemy;

	private void Update()
	{
		if (isEnemy && enemy != null)
		{
			if (enemy.gameObject.CompareTag("Rock"))
			{
				if (Input.GetMouseButtonDown(0))
				{
					enemy.gameObject.GetComponent<MedRock>().Chomp();
					Instantiate(chompParticle, transform.position, transform.rotation);
				}
				//else if (Input.GetMouseButtonUp(0))
				//{
				//	//if (enemy.gameObject.CompareTag("Gem") || enemy.gameObject.CompareTag("Bomb"))
				//	//{
				//	//	isGrabbing = false;
				//	//	gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
				//	//}
				//	//Debug.Log(enemy);
				//	switch (enemy.gameObject.name)
				//	{
				//		case "Bomb(Clone)":
				//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
				//			break;
				//		case "purple(Clone)":
				//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
				//			break;
				//		case "sapphire(Clone)":
				//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
				//			break;
				//		case "emerald(Clone)":
				//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
				//			break;
				//		case "star(Clone)":
				//			gameObject.GetComponent<GrabObjects>().ReleaseObject(enemy.gameObject);
				//			break;
				//		default:
				//			break;
				//	}
				//}
				//	{
				//if (enemy.gameObject.CompareTag("Rock"))
				//{
				//	enemy.gameObject.GetComponent<MedRock>().Chomp();
				//	Instantiate(chompParticle, transform.position, transform.rotation);
				//}
				//else if (enemy.gameObject.CompareTag("Gem") || enemy.gameObject.CompareTag("Bomb"))
				//{
				//	Debug.Log(isGrabbing);
				//	isGrabbing = true;
				//	gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
				//}
				//	Debug.Log(enemy);
				//switch (enemy.gameObject.name)
				//{
				//	case "Med Rock(Clone)":
				//		enemy.gameObject.GetComponent<MedRock>().Chomp();
				//		Instantiate(chompParticle, transform.position, transform.rotation);
				//		break;
				//	case "Bomb(Clone)":
				//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
				//		break;
				//	case "purple(Clone)":
				//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
				//		break;
				//	case "sapphire(Clone)":
				//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
				//		break;
				//	case "emerald(Clone)":
				//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
				//		break;
				//	case "star(Clone)":
				//		gameObject.GetComponent<GrabObjects>().GrabObject(enemy.gameObject);
				//		break;
				//	default:
				//		break;
				//}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		enemy = other;
		isEnemy = true;
	}

	void OnTriggerExit(Collider other)
	{
		isEnemy = false;
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (other.gameObject.CompareTag("Gem"))
			{
				gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
			}
			else if (other.gameObject.CompareTag("Bomb"))
			{
				isGrabbing = true;
				gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			if (other.gameObject.CompareTag("Gem"))
			{
				gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
			}
			else if (other.gameObject.CompareTag("Bomb"))
			{
				isGrabbing = false;
				gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
			}
				//switch (other.gameObject.name)
				//{
				//	case "Bomb(Clone)":
				//		isGrabbing = false;
				//		gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
				//		break;
				//	case "purple(Clone)":
				//		gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
				//		break;
				//	case "sapphire(Clone)":
				//		gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
				//		break;
				//	case "emerald(Clone)":
				//		gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
				//		break;
				//	case "star(Clone)":
				//		gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
				//		break;
				//	default:
				//		break;
				//}
		}
	}
}
