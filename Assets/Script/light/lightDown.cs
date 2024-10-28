using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDown : MonoBehaviour
{
    public Animator LightDown;
    //public Animator tonedown;
    // Start is called before the first frame update
    void Start()
    {
        LightDown.SetBool("play", false);
        //tonedown.SetBool("play", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            LightDown.SetBool("play", true);
            //tonedown.SetBool("play", true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
