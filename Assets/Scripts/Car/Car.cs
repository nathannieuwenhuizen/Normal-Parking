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

    [SerializeField]
    List<WheelCollider> wheelCollider = new List<WheelCollider>();
    [SerializeField]
    List<Transform> wheelTransform = new List<Transform>();
    [SerializeField]
    float maxMoterTorque;
    [SerializeField]
    float maxStreeingAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int  i=0;i<4;i++)
        {
            Vector3 position;
            Quaternion rotation;
            wheelCollider[i].GetWorldPose(out position, out rotation);

            wheelTransform[i].transform.position = position;
            wheelTransform[i].transform.rotation = rotation;

           
        }
              
    }

    /*
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
    */
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            GameManager.OnCollission?.Invoke();
            //GetComponent<InputHandeler>().enabled = false;
            //radioSource.clip = deathRadioClip;
            //radioSource.volume = .5f;
            //radioSource.Play();
            Instructor.instance.ParkingFail();

            //if (collision.gameObject.GetComponent<AudioSource>())
            //{
            //    foreach (AudioSource audioS in collision.gameObject.GetComponents<AudioSource>())
            //    {
            //        audioS.Play();
            //    }
            //}
        }
    }

    private void FixedUpdate()
    {

        float moter = Input.GetAxis("Vertical");
        float streeing = Input.GetAxis("Horizontal");
       

        float finalAngle = streeing * 45f;
        wheelCollider[0].steerAngle = finalAngle;
        wheelCollider[1].steerAngle = finalAngle;



        foreach (WheelCollider wheel in wheelCollider)
        {
            wheel.motorTorque = moter * maxMoterTorque;
            wheel.brakeTorque = 0;
           
        }
        /*
        if (Input.GetKey(KeyCode.A))
        {
            Debug.LogError("stop");

           foreach(WheelCollider wheel in wheelCollider)
            {
                wheel.brakeTorque = 50;
            }
        }
        else
        {
            foreach(WheelCollider wheel in wheelCollider)
            {
                wheel.brakeTorque = 0;
            }
        }
        */

        


    }

}
