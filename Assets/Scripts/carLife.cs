using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carLife : MonoBehaviour
{
    [SerializeField]
    int life;
    [SerializeField]
    Text lifeText;


    private void Update()
    {

        if (life <= 0)
        {
            Globals.RESULT = Result.ZombieEat;
            SceneHandeler.GoToScene(2);
        }

        lifeText.text = "Life:"+life.ToString();
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





