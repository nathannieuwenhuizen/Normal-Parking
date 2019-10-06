using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carLife : MonoBehaviour
{
    [SerializeField]
    int life;
    [SerializeField]
    Text lifeText;

 

    // Start is called before the first frame update
    void Start()
    {


       
    }
    private void Update()
    {
       
       

        lifeText.text = life.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Zombie")
        {

            Debug.LogError("Zombie");
            life -= 30;
            Debug.LogError("life"+life);


        }



    }

}





