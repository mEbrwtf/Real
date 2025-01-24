using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NottrueEnding2 : MonoBehaviour
{
    public bool inReach;
    public AudioSource ring;
    public AudioSource ppickup;
    public Collider end;
    public Collider notpickup;
    public Collider pickup; // Collider to prevent pickup
    public Collider door;
    private Coroutine ringCoroutine; // Coroutine to manage ring audio duration

    void Start()
    {
        inReach = false;
        pickup.enabled = false;
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
        end.enabled = true; // Activate the end object
        door.enabled = true; // Enable the door collider

        // Call NotPickUp() to disable pickup
        PickUp();
    }

    private IEnumerator RingDuration()
    {
        yield return new WaitForSeconds(37f);
        ring.Play();
        pickup.enabled = true;
        yield return new WaitForSeconds(32f);
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
