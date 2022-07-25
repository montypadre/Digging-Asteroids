using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsBehavior : MonoBehaviour
{
    public int damage = 40;
	bool isChomping;

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
							other.gameObject.GetComponent<Bomb>().Chomp();
							break;
						case "Gold Rock(Clone)":
							other.gameObject.GetComponent<GoldRock>().Chomp();
							break;
						default:
							break;
					}
			}
		}
	}
}
