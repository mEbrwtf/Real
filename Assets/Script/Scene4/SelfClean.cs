using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfClean : MonoBehaviour
{
    public GameObject OldFloor;
    public GameObject NewFloor;

    bool inReach = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Trigger detection for when the player enters the "Reach" zone
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach");
            inReach = true; // Mark the player as within reach
        }
    }

    // Trigger detection for when the player exits the "Reach" zone
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false; // Mark the player as out of reach
        }
    }

    void Update()
    {
        // If the player is in reach and presses the "Click" button
        if (inReach && Input.GetButtonDown("Click"))
        {
            NewFloor.SetActive(true);
            OldFloor.SetActive(false);
        }
    }
}