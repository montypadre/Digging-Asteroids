using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsBehavior : MonoBehaviour
{
    //public int damage = 40;
	public bool isGrabbing = false;

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
						break;
					case "Sm Rock(Clone)":
						other.gameObject.GetComponent<SmRock>().Chomp();
						break;
					case "Bomb(Clone)":
						isGrabbing = true;
						gameObject.GetComponent<GrabObjects>().GrabObject(other.gameObject);
						break;
					case "Gold Rock(Clone)":
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
					case "Gold Rock(Clone)":
						gameObject.GetComponent<GrabObjects>().ReleaseObject(other.gameObject);
						break;
					default:
						break;
				}
			}
		}
	}
}
