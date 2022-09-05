using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    public int maxGoldAmt = 100;
    public int currentGold;
    public GameObject chuteParticle;
    public GameObject particleSpawn;
    public GameObject chuteParticleSmoke;
    //private Coroutine comboTimer;
    //private int numGold = 0;
    //private float combo;
    //private bool isCombo;
    //private float secondsCount;
    public float timeRemaining;
    private bool timerIsRunning = false;
    private int comboGold = 0;

    public GoldMeter goldMeter;
    void Start()
    {
        currentGold = 0;
        //goldMeter.SetMaxGoldAmt(maxGoldAmt);
    }

	private void Update()
	{
        //Debug.Log(timeRemaining);
        if (timerIsRunning)
		{
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
			{
                // When Timer finishes, increment gold amt by Combo amt
                timeRemaining = 0;
                timerIsRunning = false;
                goldMeter.slider.value += comboGold;
                comboGold = 0;
			}
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        //Debug.Log(other);
        if (other.gameObject.name == "purple(Clone)" || other.gameObject.name == "sapphire(Clone)" || other.gameObject.name == "emerald(Clone)" || other.gameObject.name == "star(Clone)")
		{
            //Debug.Log(other.gameObject.name);
            //numGold++;
            goldMeter.slider.value += 2;                // Bar Increase
            //StartCoroutine(ComboTimer());
            //ComboTimer();

             if (timerIsRunning)
            {
                comboGold++;
            }

            ///////PSEUDOCODE////////
            // Start Timer
            timerIsRunning = true;
            timeRemaining = 10;
            // If another piece is collected before timer reaches 0
            // Increment Combo by 1

            // Restart Timer (self)

            // If gold or bomb hit trigger, remove
            Destroy(other.gameObject);
            Instantiate(chuteParticle, particleSpawn.transform.position, particleSpawn.transform.rotation);
        }
        if (other.gameObject.name == "Bomb(Clone)")
		{
            Destroy(other.gameObject);
            Instantiate(chuteParticleSmoke, particleSpawn.transform.position, particleSpawn.transform.rotation);
        }
    }

 //   IEnumerator ComboTimer()
	//{
 //       Debug.Log("Entered Combo");
 //       Debug.Log("Entered numGold: " + numGold);
 //       Debug.Log("Entered combo: " + combo);
 //       if (numGold >= 1)
	//	{
 //           combo = numGold;
 //       }
 //       // combo = numGold;
 //       yield return new WaitForSeconds(3f);
 //       if (combo == 0)
	//	{
 //           numGold = 0;
	//	}
 //       else if (combo >= 1)
	//	{
 //           StartCoroutine(ComboTimer());
	//	}
 //       Debug.Log("Exxit Combo");
 //       Debug.Log("Exit numGold: " + numGold);
 //       Debug.Log("Exit combo: " + combo);
 //   }

 //   private void ComboTimer()
	//{
 //       while (secondsCount >= 3.0f)
	//	{
 //           secondsCount += Time.deltaTime;
	//	}
 //       return;
	//}
}
