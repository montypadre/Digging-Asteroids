using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsBehavior : MonoBehaviour
{
    //public int damage = 40;
	public bool isGrabbing = false;
	public ParticleSystem chompParticle;
	public GameObject spawnPoint;

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			if (Input.GetMouseButtonDown(0))
			{
				switch (other.gameObject.name)
				{
					case "Big Rock(Clone)":
						other.gameObject.GetComponent<BigRock>().Chomp();
						break;
					case "Med Rock(Clone)":
						other.gameObject.GetComponent<MedRock>().Chomp();
						Instantiate(chompParticle,transform.position, transform.rotation);
						break;
					case "Sm Rock(Clone)":
						other.gameObject.GetComponent<SmRock>().Chomp();
						break;
					case "Bomb(Clone)":
						isGrabbing = true;
						gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
						break;
					case "purple(Clone)":
						gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
						break;
					case "sapphire(Clone)":
						gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
						break;
					case "emerald(Clone)":
						gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
						break;
					case "star(Clone)":
						gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
						break;
					default:
						break;
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				switch (other.gameObject.name)
				{
					case "Bomb(Clone)":
						isGrabbing = false;
						gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
						break;
					case "purple(Clone)":
						gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
						break;
					case "sapphire(Clone)":
						gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
						break;
					case "emerald(Clone)":
						gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
						break;
					case "star(Clone)":
						gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
						break;
					default:
						break;
				}
			}
		}
	}
}
