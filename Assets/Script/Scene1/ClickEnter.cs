using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ClickEnter : MonoBehaviour
{
    public List<AudioSource> audioSources; // List of AudioSources to handle multiple audio clips
    public List<string> subtitles; // List of subtitles corresponding to each audio clip
    public List<float> audioDelays; // List of delays corresponding to each audio clip
    public Collider triggerCollider; // Collider to define the activation zone
    public static ClickEnter activeTrigger; // Tracks the currently active TriggerAudioManager instance
    public int currentAudioIndex = 0; // Tracks the current audio in the list
    public List<Collider> nextTriggers; // List of next triggers to activate progressively after each clip

    [Header("UI Elements")]
    public Text subtitleText; // Reference to the UI Text element for displaying subtitles

    [Header("Audio Start Delay")]
    public float initialDelay = 1.0f; // Delay before starting the audio sequence

    [Header("Key Settings")]
    public KeyCode activationKey = KeyCode.E; // Key to activate the audio sequence

    private bool isPlayerInZone = false; // Tracks if the player is in the trigger zone

    void Start()
    {
        subtitleText.text = ""; // Clear the subtitle text at the start
    }

    void Update()
    {
        // Check if the player is in the zone and presses the activation key
        if (isPlayerInZone && Input.GetKeyDown("USE"))
        {
            if (activeTrigger != null && activeTrigger != this) // If there's an active trigger and it's not this one
            {
                activeTrigger.ResetAudioManager(); // Reset the previous trigger
            }

            activeTrigger = this; // Set this trigger as the active one
            StartCoroutine(StartAudioWithDelay(initialDelay)); // Start the audio sequence with the initial delay
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            isPlayerInZone = true; // Set player in zone to true
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            isPlayerInZone = false; // Set player in zone to false
        }
    }

    private System.Collections.IEnumerator StartAudioWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified initial delay
        PlayAudio(); // Start playing the audio sequence
    }

    void ResetAudioManager()
    {
        StopAllAudio(); // Stop all audio sources
        subtitleText.text = ""; // Clear the subtitle text
        currentAudioIndex = 0; // Reset the audio index
        StopAllCoroutines(); // Stop any running coroutines
    }

    void StopAllAudio()
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop each audio source
            }
        }
    }

    void PlayAudio()
    {
        StopAllAudio(); // Stop all audio sources before playing the current one

        AudioSource currentPlayingAudio = audioSources[currentAudioIndex];
        currentPlayingAudio.Play(); // Play the current audio

        DisplaySubtitle(currentAudioIndex); // Display the corresponding subtitle

        // Wait for the audio to finish and play the next one
        StartCoroutine(PlayNextAudioAfterCurrentEnds(currentPlayingAudio.clip.length, audioDelays[currentAudioIndex]));
    }

    void DisplaySubtitle(int index)
    {
        if (index < subtitles.Count) // Check if index is valid
        {
            subtitleText.text = subtitles[index]; // Display the corresponding subtitle
        }
    }

    private System.Collections.IEnumerator PlayNextAudioAfterCurrentEnds(float audioLength, float audioDelay)
    {
        yield return new WaitForSeconds(audioLength); // Wait for the audio to finish

        subtitleText.text = ""; // Clear the subtitle text

        yield return new WaitForSeconds(audioDelay); // Wait for the specified delay

        if (currentAudioIndex < nextTriggers.Count)
        {
            nextTriggers[currentAudioIndex].enabled = true; // Enable the next trigger
        }

        currentAudioIndex++; // Move to the next audio

        if (currentAudioIndex < audioSources.Count) // Check if there's a next audio
        {
            PlayAudio(); // Play the next audio
        }
    }
}
