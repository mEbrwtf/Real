using System.Collections;
using UnityEngine;

public class Two1 : MonoBehaviour
{
    [Header("Trigger Settings")]
    public Collider own; // Reference to the collider
    public bool deactivateOnExit = true; // Option to deactivate collider when player exits

    [Header("Initial Object Settings")]
    public Animator initialObject; // Animator to control after subs and audios
    public string activationParameter = "Open"; // Parameter name in Animator
    public int activateAnimatorAfter = -1; // Index after which to activate Animator (-1 to skip)
    public float finalDelay = 2f; // Delay before activating Animator

    [Header("Sub Objects Settings")]
    public GameObject[] subs; // Array for Sub objects
    public AudioSource[] subAudios; // Corresponding audio sources for each Sub
    public float[] delays; // Array of delays before activating each Sub
    public float[] durations; // Array of durations for each Sub to remain active

    [Header("Post-Sequence Object Activation")]
    public GameObject[] objectsToActivate; // Objects to activate after subs and audios
    public int activateObjectsAfter = -1; // Index after which to activate objects (-1 to skip)
    public float postActivationDelay = 0f; // Optional delay before activating these objects

    private bool isTriggered = false; // Flag to check if coroutine is running

    void Start()
    {
        // Validate the arrays' lengths
        if (subs.Length > 0 && (subs.Length != subAudios.Length || subs.Length != delays.Length || subs.Length != durations.Length))
        {
            Debug.LogError("Ensure all arrays (subs, subAudios, delays, durations) have the same length.");
        }

        // Ensure Animator is initially inactive
        if (initialObject != null)
        {
            initialObject.enabled = false; // Disable Animator initially
        }

        // Ensure objects to activate are initially inactive
        foreach (var obj in objectsToActivate)
        {
            if (obj != null) obj.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(HandleSequence());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && deactivateOnExit)
        {
            own.enabled = false; // Optionally disable the collider when player exits
        }
    }

    private IEnumerator HandleSequence()
    {
        // Sequentially activate subs and audios
        for (int i = 0; i < subs.Length; i++)
        {
            yield return new WaitForSeconds(delays[i]);
            yield return ActivateSub(i, durations[i]);

            // Check if the Animator should be activated after this sub/audio
            if (i == activateAnimatorAfter && initialObject != null)
            {
                yield return new WaitForSeconds(finalDelay);
                initialObject.enabled = true; // Enable Animator
                initialObject.SetBool(activationParameter, true); // Set Animator parameter
            }

            // Check if the additional objects should be activated after this sub/audio
            if (i == activateObjectsAfter)
            {
                yield return new WaitForSeconds(postActivationDelay);
                foreach (var obj in objectsToActivate)
                {
                    if (obj != null) obj.SetActive(true);
                }
            }
        }

        isTriggered = false; // Reset flag
    }

    private IEnumerator ActivateSub(int index, float duration)
    {
        // Activate Sub object
        if (index < subs.Length && subs[index] != null)
        {
            subs[index].SetActive(true);
        }

        // Play corresponding audio
        if (index < subAudios.Length && subAudios[index] != null)
        {
            subAudios[index].Play();
        }

        // Wait for specified duration
        yield return new WaitForSeconds(duration);

        // Deactivate Sub object
        if (index < subs.Length && subs[index] != null)
        {
            subs[index].SetActive(false);
        }
    }

    // Public method to reset the script's logic
    public void ResetTrigger()
    {
        isTriggered = false;
        own.enabled = true;

        // Reset Animator parameter and state
        if (initialObject != null)
        {
            initialObject.enabled = false; // Disable Animator
            initialObject.SetBool(activationParameter, false);
        }

        // Deactivate all subs
        foreach (var sub in subs)
        {
            if (sub != null) sub.SetActive(false);
        }

        // Deactivate all objects that were set to be activated at the end
        foreach (var obj in objectsToActivate)
        {
            if (obj != null) obj.SetActive(false);
        }
    }
}
