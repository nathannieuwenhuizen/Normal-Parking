using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
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

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        PlaySound(introduction);
    }

    void Update()
    {
        Vector3 relativePos = Vector3.Normalize(carTransform.InverseTransformPoint(goalTransform.position));
        Debug.Log(relativePos);

    }
    public void GiveDirection()
    {
        Vector3 relativePos = Vector3.Normalize(carTransform.InverseTransformPoint(goalTransform.position));
        Debug.Log(relativePos);

        if (relativePos.z < - 0.5f)
        {
            PlaySound(behindSound, 1.5f, relativePos.x);
        }
        else
        {
            if (relativePos.x > 0f)
            {
                PlaySound(tooRightSound, 1.5f, relativePos.x);
            }
            else
            {
                PlaySound(tooLeftSound, 1.5f, relativePos.x);
            }
        }
    }

    public void ParkingSucces()
    {
        PlaySound(parkWinSound);
    }

    //TODO: needs implementation!
    public void ParkingFail()
    {
        PlaySound(parkFailSound);
    }

    public void PlaySound(AudioClip clip, float volume = 1f, float pan = 0f)
    {
        audioSource.panStereo = pan;
        audioSource.volume = volume;
        audioSource.clip = clip;

        audioSource.Play();
    }

}
