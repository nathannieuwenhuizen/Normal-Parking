using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSound : MonoBehaviour
{


    [SerializeField]
    AudioClip destrucrion;
    [SerializeField]
    AudioClip alam;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(destrucrion);
            audioSource.PlayOneShot(alam);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
