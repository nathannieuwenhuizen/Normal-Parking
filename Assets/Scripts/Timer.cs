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
        second = (int)totalTime;
        StartCoroutine(CountingDown());
    }

    IEnumerator CountingDown()
    {
        UpdateTimer();
        yield return new WaitForSeconds(1);
        second--;
        if (second >= 0)
        {
            StartCoroutine(CountingDown());
        }

    }
    void UpdateTimer()
    {
        timerText.text = second.ToString();
        if (second == 60)
        {
            audioSource.PlayOneShot(timerSound[0]);
        }
        else if (second == 30)
        {
            audioSource.PlayOneShot(timerSound[1]);
        }
        else if (second == 10)
        {
            audioSource.PlayOneShot(timerSound[2]);
        }
        else if (second == 5)
        {
            audioSource.PlayOneShot(timerSound[3]);
        }
        else if (second == 0)
        {
            audioSource.PlayOneShot(timerSound[4]);
        }

    }
}
