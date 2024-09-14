using System.Collections;
using UnityEngine;

public class Two1 : MonoBehaviour
{
    public Collider own;
    public GameObject[] subs;        // Array for Sub, Sub2, Sub3, etc.
    public AudioSource[] subAudios;  // Corresponding audio sources for each Sub
    public float[] delays;           // Array of delays before activating each Sub
    public float[] durations;        // Array of durations for each Sub to remain active

    private bool isTriggered = false; // Flag to check if the coroutine is already running

    void Start()
    {
        // Ensure delays and durations match subs and subAudios length
        if (subs.Length != subAudios.Length || subs.Length != delays.Length || subs.Length != durations.Length)
        {
            Debug.LogError("Make sure subs, subAudios, delays, and durations arrays are all of the same length.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            Debug.Log("hi");
            isTriggered = true;
            StartCoroutine(DelayedAction());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            own.enabled = false; // Disable the collider once the player exits
        }
    }

    private IEnumerator DelayedAction()
    {
        for (int i = 0; i < subs.Length; i++)
        {
            yield return new WaitForSeconds(delays[i]);    // Wait before activating the next Sub
            yield return ActivateSub(i, durations[i]);     // Activate Sub with corresponding duration
        }

        // If Button is removed, you can remove this logic or add any other logic needed here
        // Debug.Log("button");
        // Button.SetActive(true); // Commented out since Button is no longer used

        isTriggered = false; // Reset the flag
    }

    private IEnumerator ActivateSub(int index, float duration)
    {
        if (index < subs.Length && subs[index] != null)
        {
            subs[index].SetActive(true);    // Activate the Sub
        }
        else
        {
            Debug.LogWarning($"Subtitle GameObject at index {index} is not assigned.");
        }

        if (index < subAudios.Length && subAudios[index] != null)
        {
            subAudios[index].Play();   // Play the corresponding audio if it exists
        }

        yield return new WaitForSeconds(duration);         // Wait for the specified duration

        if (index < subs.Length && subs[index] != null)
        {
            subs[index].SetActive(false);   // Deactivate the Sub
        }
    }
}
