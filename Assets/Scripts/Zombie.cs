using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    Transform player;

    public NavMeshAgent navigation;

    [SerializeField]
    public Transform target;
    public bool trigger = true;

    [SerializeField]
    AudioClip eatYou;
    [SerializeField]
    AudioClip Attack;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        navigation = this.gameObject.GetComponent<NavMeshAgent>();

        target = GameObject.Find("Car").transform;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (target != null)
        {
            if (navigation.enabled)
            {
                navigation.destination = target.position;
            }
        }

        audioSource.PlayOneShot(Attack);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (navigation.enabled)
            {
                StartCoroutine(Bounce());
            }
           // audioSource.PlayOneShot(eatYou);
        }


    }

    IEnumerator Bounce()
    {
        navigation.enabled = false;
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 50, ForceMode.Force);
        yield return new WaitForSeconds(0.5f);
        navigation.enabled = true;
        yield break;
    }
}
