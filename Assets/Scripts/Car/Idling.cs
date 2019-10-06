using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idling : MonoBehaviour
{
    [SerializeField]
    AudioClip idling;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.2f;
        audioSource.PlayOneShot(idling);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))){
            audioSource.pitch += 0.005f;
        }
        if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S))){
            audioSource.pitch=0.3f;
        }
    }
}
