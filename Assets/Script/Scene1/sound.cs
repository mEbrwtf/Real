using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public Collider currentTrigger;
    public Collider nextTrigger;
    public AudioSource audioSource;
    public AudioSource lastAudioSource;

    void Start()
    {
        // Ensure audio is not playing at the start and next trigger is disabled
        audioSource.Stop();
        nextTrigger.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the audio for this trigger and stop the previous one
            audioSource.Play();
            lastAudioSource.Stop();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the next trigger and disable the current one
            nextTrigger.enabled = true;
            currentTrigger.enabled = false;
        }
    }
}
