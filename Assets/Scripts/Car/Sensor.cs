using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    [Range(0, 10)]
    [SerializeField]
    private float distance = 5;
    [SerializeField]
    [Range(0, 180)]
    private int angle = 45;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float maxFrequencyInterval = 1f;

    [SerializeField]
    private AudioClip beepSound;
    [SerializeField]
    private AudioClip beepContSound;

    //sensor variable
    private List<Collider> hits;
    private float distanceToClosestPoint;

    private float frequencyValue = 1;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Beeping());
    }

    // Update is called once per frame
    void Update()
    {
        RayCastSweep();
    }
    IEnumerator Beeping()
    {
        while (frequencyValue > 1)
        {
            audioSource.loop = false;
            yield return new WaitForFixedUpdate();
        }
        if (maxFrequencyInterval * frequencyValue < 0.1f)
        {
            if (audioSource.clip != beepContSound)
            {
                audioSource.clip = beepContSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        } else
        {
            audioSource.loop = false;
            audioSource.volume = 1 - frequencyValue;
            audioSource.clip = beepSound;
            audioSource.Play();
        }
        yield return new WaitForSeconds(maxFrequencyInterval * frequencyValue);
        StartCoroutine(Beeping());
    }

    void RayCastSweep()
    {
        hits = new List<Collider> { };
        distanceToClosestPoint = 100000000000;

        Vector3 startPos = transform.position; // umm, start position !
        Vector3 targetPos = Vector3.zero; // variable for calculated end position

        int startAngle = -angle / 2; // half the angle to the Left of the forward
        int finishAngle = angle / 2; // half the angle to the Right of the forward

        // the gap between each ray (increment)
        int inc = (angle / 10);

        RaycastHit hit;


        // step through and find each target point
        for (int i = startAngle; i < finishAngle; i += inc ) // Angle from forward
        {
            targetPos = transform.position +  (Quaternion.Euler(0, i, 0) * transform.forward).normalized * distance;

            // linecast between points
            if (Physics.Raycast(startPos, targetPos - startPos, out hit, distance))
            {
                if (hit.collider.gameObject.tag != "goal")
                {
                    //Debug.Log("Hit " + hit.collider.gameObject.name);
                    // to show ray just for testing
                    float hitDistanceToClosestPoint =
                        Vector3.Distance(
                            transform.position,
                            hit.point
                            );
                    distanceToClosestPoint = Mathf.Min(distanceToClosestPoint, hitDistanceToClosestPoint);
                    Debug.DrawLine(startPos, hit.point, Color.green);
                }
            }
            else
            {
                // to show ray just for testing
                Debug.DrawLine(startPos, targetPos, Color.red);

            }
            frequencyValue = distanceToClosestPoint / distance; //between 0 and 1 where 1 is almost not and 0 about to hit the object.
            //Debug.Log("distance: " + distanceToClosestPoint);
            

        }
    }
    private void OnDrawGizmosSelected()
    {
        
       // UnityEditor.Handles.color = Color.green;
       // UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, distance);

        float totalFOV = angle;
        float rayRange = distance;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
    }
}
