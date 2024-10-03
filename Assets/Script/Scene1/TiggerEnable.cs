using UnityEngine;
using UnityEngine.UI; // Make sure to include this for UI elements
using System.Collections.Generic;

public class TriggerAudioManager : MonoBehaviour
{
    public List<AudioSource> audioSources; // List of AudioSources to handle multiple audio clips
    public List<string> subtitles; // List of subtitles corresponding to each audio clip
    public List<float> delays; // List of delays corresponding to each audio clip
    public Collider triggerCollider; // To disable the collider after the audio sequence
    public static TriggerAudioManager activeTrigger; // Tracks the currently active TriggerAudioManager instance
    public int currentAudioIndex = 0; // Tracks the current audio in the list

    [Header("UI Elements")]
    public Text subtitleText; // Reference to the UI Text element for displaying subtitles

    void Start()
    {
        triggerCollider = GetComponent<Collider>(); // Get the trigger collider
        subtitleText.text = ""; // Clear the subtitle text at the start
    }

    // When the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            if (activeTrigger != null && activeTrigger != this) // If there's an active trigger and it's not this one
            {
                activeTrigger.ResetAudioManager(); // Reset the previous trigger
            }

            activeTrigger = this; // Set this trigger as the active one
            PlayAudio(); // Start playing the audio sequence
        }
    }

    // Completely reset the audio manager
    void ResetAudioManager()
    {
        StopAllAudio(); // Stop all audio sources
        subtitleText.text = ""; // Clear the subtitle text
        currentAudioIndex = 0; // Reset the audio index
        StopAllCoroutines(); // Stop any running coroutines
    }

    // Stop all audio playback
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

    // Play the current audio
    void PlayAudio()
    {
        // Stop all audio sources before playing the current one
        StopAllAudio();

        // Play the current audio in the list
        AudioSource currentPlayingAudio = audioSources[currentAudioIndex];
        currentPlayingAudio.Play();

        // Display the corresponding subtitle
        DisplaySubtitle(currentAudioIndex);

        // Start a coroutine to wait for the audio to finish and play the next one
        StartCoroutine(PlayNextAudioAfterCurrentEnds());
    }

    // Display the subtitle for the current audio index
    void DisplaySubtitle(int index)
    {
        if (index < subtitles.Count) // Check if index is valid
        {
            subtitleText.text = subtitles[index]; // Display the corresponding subtitle
        }
    }

    // Coroutine to wait for the audio to finish and then play the next one
    private System.Collections.IEnumerator PlayNextAudioAfterCurrentEnds()
    {
        // Wait until the current audio clip is finished
        yield return new WaitForSeconds(audioSources[currentAudioIndex].clip.length);

        // Get the delay for the next audio from the list
        float nextDelay = (currentAudioIndex < delays.Count) ? delays[currentAudioIndex] : 0f;

        // Delay before playing the next audio
        yield return new WaitForSeconds(nextDelay);

        // Clear the current subtitle
        subtitleText.text = "";

        // Move to the next audio
        currentAudioIndex++;

        if (currentAudioIndex < audioSources.Count) // Check if there's a next audio
        {
            PlayAudio(); // Play the next audio
        }
        else
        {
            // Optionally disable the trigger collider here if you want to do so after the last audio
            // triggerCollider.enabled = false;
        }
    }

    // When the player exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            // Disable the collider immediately when the player exits
            triggerCollider.enabled = false; // Disable the trigger collider
        }
    }
}
