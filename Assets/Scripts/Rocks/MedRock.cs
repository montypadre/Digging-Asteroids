using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedRock : RockController
{
    public override void Chomp()
	{
        Instantiate(rocks[Random.Range(0, rocks.Length)], transform.localPosition, transform.localRotation);
        Destroy(gameObject);
    }

    public int GetID()
    {
        return gameObject.GetInstanceID();
    }
}
