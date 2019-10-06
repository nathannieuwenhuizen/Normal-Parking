using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text timerText;
    [SerializeField]
    float totalTime=60;
    int second;

    [SerializeField]
    List<AudioClip> timerSound = new List<AudioClip>();
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        second = (int)totalTime;
        timerText.text = second.ToString();
        if (second == 59)
        {
            audioSource.PlayOneShot(timerSound[0]);
            Debug.LogError("59");
        }else if (second == 31)
        {
            audioSource.PlayOneShot(timerSound[1]);
            Debug.LogError("31");
        }else if (second == 11)
        {
            audioSource.PlayOneShot(timerSound[2]);
        }else if (second == 6)
        {
            audioSource.PlayOneShot(timerSound[3]);
        }else if (second == 0)
        {
            audioSource.PlayOneShot(timerSound[4]);
        }


    }
}
