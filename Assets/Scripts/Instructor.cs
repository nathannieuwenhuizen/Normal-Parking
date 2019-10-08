using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    private Timer timer;
    public static Instructor instance;
    AudioSource audioSource;

    [SerializeField]
    private Transform goalTransform;

    [SerializeField]
    private Transform carTransform;

    [Header("Directional sounds")]
    [SerializeField]
    private AudioClip tooLeftSound;
    [SerializeField]
    private AudioClip aBitLeftSound;
    [SerializeField]
    private AudioClip frontSound;
    [SerializeField]
    private AudioClip aBitRightSound;
    [SerializeField]
    private AudioClip tooRightSound;
    [SerializeField]
    private AudioClip behindSound;

    [Header("State sounds")]
    [SerializeField]
    private AudioClip introduction;
    [SerializeField]
    private AudioClip parkFailSound;
    [SerializeField]
    private AudioClip parkWinSound;
    [SerializeField]
    List<AudioClip> timecont = new List<AudioClip>();

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        PlaySound(introduction);
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
    }

    void Update()
    {
        Vector3 relativePos = Vector3.Normalize(carTransform.InverseTransformPoint(goalTransform.position));
        //Debug.Log(relativePos);
        /*
        if (timer.Getsecond. == 59)
        {
            PlaySound(timecont[0]);
        }else if (timer.Getsecond == 31)
        {
            PlaySound(timecont[1]);
        }else if (timer.Getsecond == 11)
        {
            PlaySound(timecont[2]);
        }else if (timer.Getsecond == 6)
        {
            PlaySound(timecont[3]);
        }else if (timer.Getsecond == 0)
        {
            PlaySound(timecont[4]);
        }*/

    }
    public void GiveDirection()
    {
        float volume = 0.3f;
        Vector3 relativePos = Vector3.Normalize(carTransform.InverseTransformPoint(goalTransform.position));
        Debug.Log(relativePos);

        if (relativePos.z < - 0.5f)
        {
            PlaySound(behindSound, volume, relativePos.x);
        }
        else
        {
            if ( relativePos.z > 0.95f )
            {
                PlaySound(frontSound, volume, relativePos.x);
                return;
            }

            if (relativePos.x < 0f)
            {
                if (relativePos.x < 0.5f)
                {
                    PlaySound(tooRightSound, volume, relativePos.x);
                }
                else
                {
                    PlaySound(aBitRightSound, volume, relativePos.x);

                }
            }
            else
            {
                if (relativePos.x > 0.5f)
                {
                    PlaySound(tooLeftSound, volume, relativePos.x);
                }
                else
                {
                    PlaySound(aBitLeftSound, volume, relativePos.x);
                }

            }
        }
    }

    public void ParkingSucces()
    {
        Globals.RESULT = Result.Parking;
        SceneHandeler.GoToScene(2);
    }

    //TODO: needs implementation!
    public void ParkingFail()
    {
        PlaySound(parkFailSound);
    }

    public void PlaySound(AudioClip clip, float volume = .7f, float pan = 0f)
    {
        audioSource.panStereo = pan;
        audioSource.volume = volume;
        audioSource.clip = clip;

        audioSource.Play();
    }

}
