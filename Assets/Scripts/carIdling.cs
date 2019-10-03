using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carIdling : MonoBehaviour
{
    [SerializeField]
    AudioClip carIdlingSound;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.PlayOneShot(carIdlingSound);
        if ((Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.S)))   
         {

            audioSource.pitch += 0.005f;
        
        }
        else if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
        {
            audioSource.pitch = 0.6f;
            Debug.LogError("up");
         
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.pitch = 0.4f;
            Debug.LogError("up");

        }
    }
}
