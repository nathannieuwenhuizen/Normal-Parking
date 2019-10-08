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

    private bool zombieMode = false;

    public static Timer instance;
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        ParkingTimerStart();
    }

    IEnumerator CountingDown()
    {
        if (zombieMode)
        {
            UpdateTimerZombieMode();

        } else
        {
            UpdateTimerParkingMode();
        }
        yield return new WaitForSeconds(1);
        second--;
        if (second >= 0)
        {
            StartCoroutine(CountingDown());
        }

    }
    public void ZombieTimerStart()
    {
        if (zombieMode) { return; }
        StopAllCoroutines();

        zombieMode = true;
        second = (int)totalTime;
        StartCoroutine(CountingDown());
    }
    public void ParkingTimerStart()
    {
        second = (int)totalTime;
        StartCoroutine(CountingDown());
    }
    private void UpdateTimerParkingMode()
    {
        timerText.text = second.ToString();
        if (second == 60)
        {
            //Instructor.instance?.PlaySound(timerSound[0]);
        }
        else if (second == 30)
        {
            Instructor.instance?.PlaySound(timerSound[1]);
        }
        else if (second == 10)
        {
            Instructor.instance?.PlaySound(timerSound[2]);
        }
        else if (second == 5)
        {
            Instructor.instance?.PlaySound(timerSound[3]);
        }
        else if (second == 0)
        {
            Globals.RESULT = Result.TooLongPark;
            SceneHandeler.GoToScene(2);

            Instructor.instance?.PlaySound(timerSound[4]);
        }

    }
    private void UpdateTimerZombieMode()
    {
        timerText.text = second.ToString();
        if (second == 0)
        {
            Globals.RESULT = Result.ZombieSurvive;
            SceneHandeler.GoToScene(2);
        }

    }
}
