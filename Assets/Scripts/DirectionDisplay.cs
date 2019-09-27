using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDisplay : MonoBehaviour
{
    [SerializeField]
    List<GameObject> direction = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            direction[0].GetComponent<Renderer>().material.color = Color.red;
        }else if (Input.GetKeyDown("right"))
        {
            direction[1].GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Input.GetKeyDown("left"))
        {
            direction[2].GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Input.GetKeyDown("down"))
        {
            direction[3].GetComponent<Renderer>().material.color = Color.red;
        }


        if (Input.GetKeyUp("up"))
        {
            direction[0].GetComponent<Renderer>().material.color = Color.white;
        }
        else if (Input.GetKeyUp("right"))
        {
            direction[1].GetComponent<Renderer>().material.color = Color.white;
        }
        else if (Input.GetKeyUp("left"))
        {
            direction[2].GetComponent<Renderer>().material.color = Color.white;
        }
        else if (Input.GetKeyUp("down"))
        {
            direction[3].GetComponent<Renderer>().material.color = Color.white;
        }


    }
}
