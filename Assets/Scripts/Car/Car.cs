using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [Header("MovementSpeed")]
    [Range(0, 5)]
    [SerializeField]
    private float forwardSpeed = 2f;
    [Range(0, 3)]
    [SerializeField]
    private float backwardSpeed = 2f;
    [Range(0, 10)]
    [SerializeField]
    private float rotateSpeed = 2f;

    [Header("Sounds")]
    [SerializeField]
    private AudioSource radioSource;
    [SerializeField]
    private AudioClip deathRadioClip;

    //private vars
    private Vector3 tempSpeed;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drive(float input)
    {
        tempSpeed = rb.velocity;
        if (input < 0)
        {
            tempSpeed = transform.forward * input * backwardSpeed;
        } else
        {
            tempSpeed = transform.forward * input * forwardSpeed;
        }
        rb.velocity = tempSpeed;
    }
    public void Turn(float input)
    {
        transform.Rotate(new Vector3(0, (Mathf.Abs(Vector3.Distance(Vector3.zero, rb.velocity)) / forwardSpeed) * (input * rotateSpeed), 0));
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            GameManager.OnCollission?.Invoke();
            GetComponent<InputHandeler>().enabled = false;
            radioSource.clip = deathRadioClip;
            radioSource.volume = .5f;
            radioSource.Play();
            if (collision.gameObject.GetComponent<AudioSource>())
            {
                foreach (AudioSource audioS in collision.gameObject.GetComponents<AudioSource>())
                {
                    audioS.Play();
                }
            }
        }
    }
}
