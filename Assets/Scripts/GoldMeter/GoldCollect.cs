using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    public int maxGoldAmt = 100;
    public int currentGold;

    public GoldMeter goldMeter;
    void Start()
    {
        currentGold = 0;
        //goldMeter.SetMaxGoldAmt(maxGoldAmt);
    }

    private void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
        //Debug.Log(other);
        if (other.gameObject.name == "Gold Rock(Clone)")
		{
            //Debug.Log(other.gameObject.name);
            goldMeter.slider.value += 2;
        }
	}
}
