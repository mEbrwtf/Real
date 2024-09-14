using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject self;
    public GameObject ff;
    public GameObject nn;
    public Animator wall;
    public GameObject[] subs;        // Array for Sub, Sub2, Sub3, etc.
    public AudioSource[] subAudios;  // Corresponding audio sources for each Sub
    bool inReach;

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            Debug.Log("Button in reach!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            ButtonClick();
        }
    }

    void ButtonClick()
    {

        // Animate wall
        wall.SetBool("Down", true);
        ff.SetActive(true);
        // Deactivate the button object
        nn.SetActive(false);
        self.SetActive(false);

        // Stop audios and deactivate subs
        for (int i = 0; i < subs.Length; i++)
        {
            if (subs[i] != null)
            {
                subs[i].SetActive(false);  // Disable subtitle
                Debug.Log("Deactivated subtitle: " + subs[i].name);
            }
            if (subAudios.Length > i && subAudios[i] != null)
            {
                subAudios[i].Stop();   // Stop corresponding audio
                Debug.Log("Stopped audio: " + subAudios[i].name);
            }
        }
    }
}
