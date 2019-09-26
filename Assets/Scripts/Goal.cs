using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static Goal instance;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

    }
    public void EmitSound(Transform carTransform)
    {
        Vector3 relativePos =carTransform.InverseTransformDirection(transform.position);
        Debug.Log(relativePos);
        audioSource.panStereo = Vector3.Normalize(relativePos).x;
        audioSource.Play();
    }
}
