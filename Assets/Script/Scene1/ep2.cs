using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioManager : MonoBehaviour
{
    public static AudioSource currentAudioSource;

    public AudioSource audioSource;
    public Collider triggerCollider;

    void Start()
    {
        // Get the AudioSource component and the Collider component
        audioSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<Collider>();

        // Ensure the GameObject has an AudioSource component
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the GameObject has a Collider component and it's set as a trigger
        if (triggerCollider == null)
        {
            triggerCollider = gameObject.AddComponent<BoxCollider>();
            triggerCollider.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Stop the current audio if it is playing
            if (currentAudioSource != null && currentAudioSource.isPlaying)
            {
                currentAudioSource.Stop();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Play the audio clip if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                currentAudioSource = audioSource; // Set this as the current playing audio

                // Disable the trigger to prevent repeated triggering
                triggerCollider.enabled = false;
            }
        }
    }
}