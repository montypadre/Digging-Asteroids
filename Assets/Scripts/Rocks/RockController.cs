using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 100f);
    }

	private void Update()
	{
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0)
        {
            rb.AddForce(Vector2.right * 10, ForceMode.Impulse);
        }
        else if (screenPos.x > Screen.width)
        {
            rb.AddForce(Vector2.left * 10, ForceMode.Impulse);
        }
        //else if (screenPos.y > Screen.height)
        //{
        //    rb.AddForce(Vector2.down * 10, ForceMode.Impulse);
        //}
        //else if (screenPos.y < 0)
        //{
        //    rb.AddForce(Vector2.up * 10, ForceMode.Impulse);
        //}
    }

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
