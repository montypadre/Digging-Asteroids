using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private Rigidbody rb;
    public int damage;
    public float damageCooldown = 0.5f;
    public float currentTime;
    public float gravity;
    //public int health = 100;
    //private int currentHealth = 0;
    public bool isChomping;
    public GameObject[] rocks;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //currentHealth = health;
        //rb.AddForce(transform.forward * 100f);
    }

	public void Update()
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

    public virtual void Chomp()
    {
        int i = 0;
        isChomping = true;
        // Debug.Log("Chomping");
        while (isChomping)
		{
            isChomping = false;
            // Debug.Log("Instantiating");
			Instantiate(rocks[i], transform.localPosition, transform.localRotation);
            i++;
        }

        GameObject.Destroy(gameObject);
    }

    private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
