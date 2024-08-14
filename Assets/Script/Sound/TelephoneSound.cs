using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneSound : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioLowPassFilter lowPassFilter;
    private AudioHighPassFilter highPassFilter;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        highPassFilter = GetComponent<AudioHighPassFilter>();

        // Set filter properties for a telephone effect
        lowPassFilter.cutoffFrequency = 3000f;
        highPassFilter.cutoffFrequency = 300f;
    }
}
