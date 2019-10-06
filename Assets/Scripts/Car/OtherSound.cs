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
    [SerializeField]
    GameObject zombie;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.LogError("other");
            audioSource.PlayOneShot(destrucrion);
            audioSource.PlayOneShot(alam);
           Instantiate(zombie);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
