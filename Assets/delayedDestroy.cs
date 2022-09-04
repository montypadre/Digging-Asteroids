using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyThis", 1f);
    }

    void destroyThis()
    {
        Destroy(gameObject);
    }
}
