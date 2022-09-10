using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private Rigidbody rb;
    private float randomScale;
    private float randomX;
    private float randomY;
    //public int damage;
    public float damageCooldown = 0.5f;
    public float currentTime;
    public float gravity;
    public float force = 10;
    //public int health = 100;
    //private int currentHealth = 0;
    public bool isChomping;
    public GameObject[] rocks;
    private Vector3 sizeModifier;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //SIZE RANDOMIZER
        randomScale = Random.Range(-0.2f, 0.2f);
        randomX = randomScale;
        randomY = randomScale;
        sizeModifier.Set(randomX, randomY, 0);
        transform.localScale += sizeModifier;
        //currentHealth = health;
        //rb.AddForce(transform.forward * 100f);
    }

	public void Update()
	{
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0)
        {
            rb.AddForce(Vector2.right * force, ForceMode.Impulse);
        }
        else if (screenPos.x > Screen.width)
        {
            rb.AddForce(Vector2.left * force, ForceMode.Impulse);
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
            Debug.Log("RockController Chomp");
            isChomping = false;
            // Debug.Log("Instantiating");
			Instantiate(rocks[i], transform.localPosition, transform.localRotation);
            i++;
        }

        GameObject.Destroy(gameObject);
    }

    public void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
