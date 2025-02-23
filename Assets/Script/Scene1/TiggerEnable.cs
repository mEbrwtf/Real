using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TriggerAudioManager : MonoBehaviour
{
    public List<AudioSource> audioSources; // List of AudioSources to handle multiple audio clips
    public List<string> subtitles; // List of subtitles corresponding to each audio clip
    public List<float> audioDelays; // List of delays corresponding to each audio clip
    public Collider triggerCollider; // To disable the collider after the audio sequence
    public static TriggerAudioManager activeTrigger; // Tracks the currently active TriggerAudioManager instance
    public int currentAudioIndex = 0; // Tracks the current audio in the list
    public List<Collider> nextTriggers; // List of next triggers to activate progressively after each clip

    [Header("UI Elements")]
    public Text subtitleText; // Reference to the UI Text element for displaying subtitles

    [Header("Audio Start Delay")]
    public float initialDelay = 1.0f; // Delay before starting the audio sequence

    void Start()
    {
        triggerCollider = GetComponent<Collider>(); // Get the trigger collider
        subtitleText.text = ""; // Clear the subtitle text at the start
    }

    // When the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activeTrigger != null && activeTrigger != this)
            {
                activeTrigger.ResetAudioManager();
            }

            activeTrigger = this;
            StartCoroutine(StartAudioWithDelay(initialDelay));
        }
    }

    // Coroutine to start the audio after the initial delay
    private System.Collections.IEnumerator StartAudioWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified initial delay
        PlayAudio(); // Start playing the audio sequence
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

        // Display the corresponding subtitle for the entire audio length
        DisplaySubtitle(currentAudioIndex);

        // Start a coroutine to wait for the audio to finish and play the next one with delay
        StartCoroutine(PlayNextAudioAfterCurrentEnds(currentPlayingAudio.clip.length, audioDelays[currentAudioIndex]));
    }

    // Display the subtitle for the current audio index
    void DisplaySubtitle(int index)
    {   
        if (index < subtitles.Count) // Check if index is valid
        {
            subtitleText.text = subtitles[index]; // Display the corresponding subtitle
        }
    }

    // Coroutine to wait for the audio to finish and then play the next one with delay
    private System.Collections.IEnumerator PlayNextAudioAfterCurrentEnds(float audioLength, float audioDelay)
    {
        // Wait until the current audio clip is finished
        yield return new WaitForSeconds(audioLength);

        // Clear the subtitle text immediately after the audio ends
        subtitleText.text = ""; // Clear the subtitle text

        // Wait for the specified delay before moving to the next audio
        yield return new WaitForSeconds(audioDelay);

        // Activate the next trigger after the current audio
        if (currentAudioIndex < nextTriggers.Count)
        {
            nextTriggers[currentAudioIndex].enabled = true; // Enable the next trigger based on the current index
        }

        // Move to the next audio
        currentAudioIndex++;

        if (currentAudioIndex < audioSources.Count) // Check if there's a next audio
        {
            PlayAudio(); // Play the next audio
        }
        else
        {
            // Optionally disable the current trigger collider after all audios are done
            // triggerCollider.enabled = false;
        }
    }

    // When the player exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            // Optionally disable the collider immediately when the player exits
            triggerCollider.enabled = false;
        }
    }
}
