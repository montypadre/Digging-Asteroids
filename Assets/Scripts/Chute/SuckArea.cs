using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SuckArea : MonoBehaviour
{
	public float suckForce;
	public GameObject suckPoint;
	Vector3 suckPosition;

	void Start()
    {
        
    }

    void Update()
    {
        suckPosition = suckPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
		//Debug.Log(other.gameObject.name);
		//Debug.Log("Trigger Entered");
		if (other.gameObject.name == "Bomb(Clone)" || other.gameObject.name == "Gold Rock(Clone)")
		{
			//Debug.Log(other.gameObject.name);
			Debug.Log("sucking");
			//Use Physics to suck object down

			other.GetComponent<Rigidbody>().isKinematic = false;
			other.transform.SetParent(null);
			//other = null;
			other.transform.position = transform.position + transform.TransformDirection(suckPosition) * suckForce;
		}
	}
}
