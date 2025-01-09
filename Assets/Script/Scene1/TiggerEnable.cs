using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class TriggerAudioManager : MonoBehaviour
{
    public List<AudioSource> audioSources; // List of AudioSources to handle multiple audio clips
    public List<string> subtitles; // List of subtitles corresponding to each audio clip
    public Collider triggerCollider; // To disable the collider after the audio sequence
    public static TriggerAudioManager activeTrigger; // Tracks the currently active TriggerAudioManager instance
    public int currentAudioIndex = 0; // Tracks the current audio in the list

    [Header("UI Elements")]
    public Text subtitleText; // Reference to the UI Text element for displaying subtitles
    public GameObject backgroundPanel; // Reference to the UI Panel that will act as the background

    [Header("Audio and Subtitle Delay")]
    public float initialDelay = 1.0f; // Delay before starting the audio sequence
    public float subtitleSpeed = 0.05f; // Speed at which the subtitle text is revealed

    private bool isWaitingForKeyPress = false; // Tracks whether we are waiting for a key press
    private bool isTextDisplaying = false; // Ensures text is fully displayed before moving on

    void Start()
    {
        triggerCollider = GetComponent<Collider>(); // Get the trigger collider
        subtitleText.text = ""; // Clear the subtitle text at the start

        if (backgroundPanel != null)
        {
            // Set the background panel to the correct size and transparency (optional)
            RectTransform rt = backgroundPanel.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(Screen.width, Screen.height / 3); // Customize the panel size as needed
            backgroundPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f); // Optional: semi-transparent black background
        }
    }

    void Update()
    {
        if (isWaitingForKeyPress && Input.anyKeyDown && !isTextDisplaying) // Check if any key is pressed
        {
            isWaitingForKeyPress = false; // Reset waiting state
            OnKeyPress(); // Handle the key press
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            if (activeTrigger != null && activeTrigger != this) // If there's an active trigger and it's not this one
            {
                activeTrigger.ResetAudioManager(); // Reset the previous trigger
            }

            activeTrigger = this; // Set this trigger as the active one
            StartCoroutine(StartAudioWithDelay(initialDelay)); // Start the audio sequence with the initial delay
        }
    }

    private IEnumerator StartAudioWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified initial delay
        PlayAudio(); // Start playing the first audio
    }

    void ResetAudioManager()
    {
        StopAllAudio(); // Stop all audio sources
        subtitleText.text = ""; // Clear the subtitle text
        currentAudioIndex = 0; // Reset the audio index
        StopAllCoroutines(); // Stop any running coroutines
        isWaitingForKeyPress = false; // Reset waiting state
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

        AudioSource currentPlayingAudio = audioSources[currentAudioIndex]; // Play the current audio in the list
        currentPlayingAudio.Play();

        DisplaySubtitle(currentAudioIndex); // Display the corresponding subtitle

        isWaitingForKeyPress = true; // Wait for the player to press a key to continue
    }

    void DisplaySubtitle(int index)
    {
        if (index < subtitles.Count) // Check if index is valid
        {
            subtitleText.text = ""; // Clear previous subtitle text
            StartCoroutine(TypeSubtitle(subtitles[index])); // Display the current subtitle character by character
        }
    }

    private IEnumerator TypeSubtitle(string subtitle)
    {
        isTextDisplaying = true; // Mark the text as displaying

        foreach (char letter in subtitle)
        {
            subtitleText.text += letter; // Add one letter at a time
            yield return new WaitForSeconds(subtitleSpeed); // Wait for a brief moment between characters
        }

        // Once subtitle is fully displayed, stop the audio
        StopAllAudio();

        isTextDisplaying = false; // Mark the text as fully displayed
    }

    void OnKeyPress()
    {
        if (currentAudioIndex < audioSources.Count)
        {
            subtitleText.text = ""; // Clear the last subtitle when a key is pressed

            currentAudioIndex++; // Move to the next audio

            if (currentAudioIndex < audioSources.Count) // Check if there's a next audio
            {
                PlayAudio(); // Play the next audio
            }
            else
            {
                triggerCollider.enabled = false; // Disable the current trigger collider after all audios are done
                // Keep the last subtitle displayed
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            triggerCollider.enabled = false; // Optionally disable the collider immediately when the player exits
        }
    }
}
