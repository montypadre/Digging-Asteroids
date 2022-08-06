using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    float distance = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Trigger Entered");
		if (other.gameObject.name == "Bomb(Clone)" || other.gameObject.name == "Gold Rock(Clone)")
		{
            Debug.Log(other.gameObject.name);

            // Use Physics to suck object down
            other.transform.position = transform.position +
            transform.TransformDirection(Vector3.forward) * distance;
        }
	}
}
