using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfClean : MonoBehaviour
{
    public GameObject OldFloor;
    public GameObject NewFloor;

    bool inReach = false;
    public Animator door; // Animator controlling the door
    private bool isDoorOpen; // Track if the door is open

    // Start is called before the first frame update
    void Start()
    {
        //camera1.enabled = false;
        isDoorOpen = door.GetBool("Closed"); // Initialize the door state based on Animator's "Open" parameter
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
            DoorOpens();
            NewFloor.SetActive(true);
            OldFloor.SetActive(false);
            StartCoroutine(PlaySoundsWithDelay()); // Call the coroutine to play sounds with delay
        }
    }

    // Coroutine to play sounds one after the other with a delay
    IEnumerator PlaySoundsWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for the audio clip's length before moving to the next one        
                                             //DoorCloses();
        DoorOpens();
    }
    void DoorOpens()
    {
        Debug.Log("It's Opens");
        door.SetBool("Closed", true);
        door.SetBool("Open", false);
    }
    // Method to handle closing the door
    void DoorCloses()
    {
        Debug.Log("Door is closing");
        door.SetBool("Open", false); // Set the "Open" state to false
        door.SetBool("Closed", true); // Trigger the "Close" animation
        isDoorOpen = false; // Update the door state
    }
}
