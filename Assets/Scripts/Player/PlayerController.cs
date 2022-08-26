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
    public float force = 5;
    private Rigidbody rb;
    public float speed = 5f;

	void Start()
	{
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Bounce player off walls
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Mouse Look
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - screenPos.x;
        mousePos.y = mousePos.y - screenPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        angle -= 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (screenPos.x < 0)
        {
            rb.AddForce(Vector2.right * force, ForceMode.Impulse);
        }
        else if (screenPos.x > Screen.width)
        {
            rb.AddForce(Vector2.left * force, ForceMode.Impulse);
        }
        else if (screenPos.y > Screen.height)
		{
            rb.AddForce(Vector2.down * force, ForceMode.Impulse);
        }
        else if (screenPos.y < 0)
		{
            rb.AddForce(Vector2.up * force, ForceMode.Impulse);
        }

        // Move player
        if (time > 0f)
		{
            time -= Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.S))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			//transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D))
		{
			//transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime);
		}
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//transform.LookAt(ray.origin);
		//FaceMouse();
		//Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		//transform.LookAt(mousePos + Vector3.right * transform.position.y);
		//velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;    
	}

	//   void OnTriggerStay(Collider other)
	//{
	//       //Debug.Log("Entered Collision");
	//	if (Input.GetMouseButton(0))
	//	{
	//           //Debug.Log("Clicked");
	//           // Activate drill
	//           Block block = other.gameObject.GetComponent<Block>();
	//           Debug.Log(block);
	//           if (block != null)
	//		{
	//               block.DealDamage(damage);
	//		}
	//       }
	//}

	//void OnCollisionEnter(Collision collision)
	//{
	//       Debug.Log("Entered Collision");
	//       Debug.Log(collision.gameObject);
	//       if (collision.gameObject.name == "Dirt(Clone)" || collision.gameObject.name == "Gold(Clone)" || collision.gameObject.name == "Oil(Clone)")
	//	{
	//           Debug.Log("gameObject collision");
	//           bounce = 100f;
	//           rb.AddForce(collision.contacts[0].normal * bounce);
	//           isBouncing = true;
	//           Invoke("StopBounce", 0.3f);
	//	}
	//}

	//   void StopBounce()
	//{
	//       isBouncing = false;
	//}
	void FaceMouse()
	{
		//Vector3 mousePosition = Input.mousePosition;
		//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		//Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.x - transform.position.y);

		//transform.up = direction;
		// Mouse Look
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
	}
}
