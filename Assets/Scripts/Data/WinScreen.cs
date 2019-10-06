using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Result
{
    Parking,
    TooLongPark,
    ZombieEat,
    ZombieSurvive
}
public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Text messageText;
    [SerializeField]
    private AudioSource audioS;

    [SerializeField]
    private AudioClip resultClipParking;
    [SerializeField]
    private AudioClip resultClipTooLongParking;
    [SerializeField]
    private AudioClip resultClipEatenByZombies;
    [SerializeField]
    private AudioClip resultClipZombieSurvive;
    public void Start()
    {
        switch (Globals.RESULT) {
            case (Result.Parking):
                resultText.text = "You win!";
                messageText.text = "You parked your car because it is just a normal parking game";
                audioS.clip = resultClipParking;
                break;
            case (Result.TooLongPark):
                resultText.text = "You lost!";
                messageText.text = "Even snails are faster than you!";
                audioS.clip = resultClipTooLongParking;
                break;
            case (Result.ZombieEat):
                resultText.text = "You lost!";
                messageText.text = "You got eaten by hungry zombies... raw 0w0";
                audioS.clip = resultClipEatenByZombies;
                break;
            case (Result.ZombieSurvive):
                resultText.text = "You win! (sort of)";
                messageText.text = "You cant park for sh*t, but at least you escaped from the zombies.";
                audioS.clip = resultClipZombieSurvive;
                break;
        }
        if (audioS.clip != null)
        {
            audioS.Play();
        }
    }
}
