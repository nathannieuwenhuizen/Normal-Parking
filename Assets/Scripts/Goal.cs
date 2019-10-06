using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static Goal instance;
    AudioSource audioSource;
    [SerializeField]
    AudioClip goalSound;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void EmitSound(Transform carTransform)
    {
        Vector3 relativePos =carTransform.InverseTransformDirection(transform.position);
        Debug.Log(relativePos);
        //audioSource.panStereo = Vector3.Normalize(relativePos).x;
        audioSource.Play();
    }

    private void Update()
    {
        GoalSound();
    }

    void GoalSound()
    {
        if (Input.GetKey(KeyCode.H))
        {
            //Debug.LogError("Input:H");
            Instructor.instance.GiveDirection();

            //audioSource.PlayOneShot(goalSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instructor.instance.ParkingSucces();
        }
    }
}
