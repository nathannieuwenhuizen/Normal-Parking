using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text timerText;
    [SerializeField]
    float totalTime;
    int second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        second = (int)totalTime;
        timerText.text = second.ToString();
        if (totalTime <= 0)
        {
            Debug.Log("GameOver");
            //GameOver
        }
    }
}
