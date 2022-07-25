using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedRock : RockController
{
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
    }

    public override void Chomp()
	{
        Instantiate(rocks[Random.Range(0, 3)], transform.localPosition, transform.localRotation);
        GameObject.Destroy(gameObject);
    }
}
