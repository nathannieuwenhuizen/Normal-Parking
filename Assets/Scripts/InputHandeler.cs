using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandeler : MonoBehaviour
{

    private Car car;

    private readonly string driveKey = "Vertical";
    private readonly string rotateKey = "Horizontal";
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        //car.Drive(Input.GetAxis(driveKey));
        //car.Turn(Input.GetAxis(rotateKey));
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instructor.instance.GiveDirection();
            //Goal.instance.EmitSound(transform);
        }
    }
}
