using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ringing : MonoBehaviour
{
    public bool inReach;
    public AudioSource ring;
    public AudioSource ppickup;
    public GameObject end;
    public Collider notpickup;
    public Collider pickup; // Collider to prevent pickup
    public Collider door;
    private Coroutine ringCoroutine; // Coroutine to manage ring audio duration

    void Start()
    {
        ring.Play();
        inReach = false;

        // Start the ring coroutine to manage the duration
        ringCoroutine = StartCoroutine(RingDuration());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
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
        // Only allow pickup if the item is in reach and has not been picked up yet
        if (inReach && Input.GetButtonDown("USE"))
        {
            StopRingAndPickup();
        }
    }

    private void StopRingAndPickup()
    {
        // Check if the ringCoroutine is running, and stop it
        if (ringCoroutine != null)
        {
            StopCoroutine(ringCoroutine);
            ringCoroutine = null; // Clear the reference
        }
        ring.Stop(); // Stop the ringing sound
        ppickup.Play(); // Play pickup sound
        end.SetActive(true); // Activate the end object
        door.enabled = true; // Enable the door collider

        // Call NotPickUp() to disable pickup
        PickUp();
    }

    private IEnumerator RingDuration()
    {
        yield return new WaitForSeconds(20f);
        ring.Stop();
        NotPickUp();
    }

    void PickUp()
    {
        pickup.enabled = false;
        inReach = false;
        Debug.Log("Not Picked Up: The item can no longer be picked up.");
    }
    void NotPickUp()
    {
        notpickup.enabled = true;
        pickup.enabled = false;
    }
}
