using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
	public float speed;
    public float min = 2f;
    public float max = 3f;
   
    void Start()
    {
        min = transform.position.x - 7;
        max = transform.position.x + 7;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }
}
