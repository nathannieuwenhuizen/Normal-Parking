using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;

    public delegate void OnCollissionDelegate();
    public static OnCollissionDelegate OnCollission;

    private bool broken = false;
    void Start()
    {
    }
    private void OnEnable()
    {
        OnCollission += Broken;
    }
    private void OnDisable()
    {
        OnCollission -= Broken;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneHandeler.ReloadScene();
        }
    }


    public void Broken()
    {
        broken = true;
    }
}
