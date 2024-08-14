using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio3DManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Set spatial blend to 3D
        audioSource.spatialBlend = 1.0f;

        // Set minimum and maximum distance
        audioSource.minDistance = 1.0f;
        audioSource.maxDistance = 500.0f;

        // Optional: Adjust Doppler level
        audioSource.dopplerLevel = 1.0f;

        // Play the sound
        audioSource.Play();
    }
}
