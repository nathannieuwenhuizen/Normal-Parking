using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Text messageText;

    public void Start()
    {
        messageText.text = Globals.WINMESSAGE;
    }
}
