using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollissionChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            Timer.instance.ZombieTimerStart();
            Goal.instance.gameObject.SetActive(false);
        }
    }

}
