using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldMeter : MonoBehaviour
{
    public Slider slider;

	public void SetMaxGoldAmt(int amt)
	{
		slider.maxValue = amt;
		slider.value = amt;
	}

    public void SetGoldAmount(int amt)
	{
		slider.value = amt;
	}
}
