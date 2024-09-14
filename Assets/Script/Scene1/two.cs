using System.Collections;
using UnityEngine;

public class two : MonoBehaviour
{
    public Collider own;
    public GameObject Button;
    public GameObject[] subs;        // Array for Sub, Sub2, Sub3, etc.
    public AudioSource[] subAudios;  // Corresponding audio sources for each Sub
    public float[] delays;           // Array of delays before activating each Sub
    public float[] durations;        // Array of durations for each Sub to remain active

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
        if (other.CompareTag("Player"))
        {
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

        // Activate Button after the last sub
        Debug.Log("button");
        Button.SetActive(true);
    }

    private IEnumerator ActivateSub(int index, float duration)
    {
        subs[index].SetActive(true);    // Activate the Sub
        if (subAudios.Length > index && subAudios[index] != null)
        {
            subAudios[index].Play();   // Play the corresponding audio if it exists
        }
        yield return new WaitForSeconds(duration);         // Wait for the specified duration
        subs[index].SetActive(false);   // Deactivate the Sub
    }
}
