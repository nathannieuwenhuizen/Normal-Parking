using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carIdling : MonoBehaviour
{
    [SerializeField]
    AudioClip carIdlingSound;

    [SerializeField]
    private Rigidbody rb;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = carIdlingSound;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.pitch = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Vector3.Distance(Vector3.zero, rb.velocity) / 5f;
        if (rb.velocity.z < 0)
        {
            audioSource.pitch = 0.5f;
            audioSource.panStereo = -.3f;
        } else
        {
            audioSource.pitch = 1f;
            audioSource.panStereo = .3f;

        }
        //if ((Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.S)))   
        // {

        //    audioSource.pitch = 1f;

        //}
        //else if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
        //{
        //    audioSource.pitch = 0.6f;
        //    //Debug.LogError("up");

        //}
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    audioSource.pitch = 0.4f;
        //    //Debug.LogError("up");

        //}
    }
}
