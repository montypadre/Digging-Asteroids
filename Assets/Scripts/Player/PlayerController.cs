using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public int damage = 50;
    public float cooldown = 0.3f;
    public float time = 0f;
    public float bounce;
    private Rigidbody rb;
    private bool isBouncing = false;

	void Start()
	{
	    rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
        if (time > 0f)
		{
            time -= Time.deltaTime;
		}
        if (Input.GetKey(KeyCode.W))
		{
            GetComponent<Rigidbody>().AddForce(transform.up * movementSpeed * Time.deltaTime);
		}

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * -movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other)
	{
        //Debug.Log("Entered Collision");
		if (Input.GetMouseButton(0))
		{
            //Debug.Log("Clicked");
            // Activate drill
            Block block = other.gameObject.GetComponent<Block>();
            Debug.Log(block);
            if (block != null)
			{
                block.DealDamage(damage);
			}
        }
	}

	void OnCollisionEnter(Collision collision)
	{
        Debug.Log("Entered Collision");
        Debug.Log(collision.gameObject);
        if (collision.gameObject.name == "Dirt(Clone)" || collision.gameObject.name == "Gold(Clone)" || collision.gameObject.name == "Oil(Clone)")
		{
            Debug.Log("gameObject collision");
            bounce = 100f;
            rb.AddForce(collision.contacts[0].normal * bounce);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
		}
	}

    void StopBounce()
	{
        isBouncing = false;
	}
}
