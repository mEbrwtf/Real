using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoors : MonoBehaviour
{
    public Animator door;
    public AudioSource openSound;
    public AudioSource closeSound;
    public bool inReach;
    
    private bool isOpen = false; // Track door state

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            if (isOpen)
            {
                DoorCloses();
            }
            else
            {
                DoorOpens();
            }
        }
    }

    void DoorOpens()
    {
        if (!isOpen) // Only open if it's closed
        {
            Debug.Log("It Opens");
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            if (openSound) openSound.Play();
            isOpen = true;
        }
    }

    void DoorCloses()
    {
        if (isOpen) // Only close if it's open
        {
            Debug.Log("It Closes");
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            if (closeSound) closeSound.Play();
            isOpen = false;
        }
    }
}
