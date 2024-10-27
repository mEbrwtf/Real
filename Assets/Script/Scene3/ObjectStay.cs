using UnityEngine;

public class SneakyWalkAudio : MonoBehaviour
{
    public AudioSource audioSource;          // Reference to the audio source
    public Transform playerCamera;           // Reference to the player's camera
    public Transform audioSourceTransform;   // Reference to the audio source's transform
    public float closeDistance = 1.5f;       // Target distance when player turns away
    public float movementSpeed = 5f;         // Speed of the audio source movement
    private Vector3 initialForward;          // Store the initial forward direction
    private Vector3 initialAudioPosition;    // Original position of the audio source
    private bool isAudioPaused;              // Check if audio is currently paused

    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        // Record the initial forward direction and audio source position
        initialForward = playerCamera.forward;
        initialAudioPosition = audioSourceTransform.position;
        isAudioPaused = false;
    }
    void Update()
    {
        // Calculate the angle between the initial direction and the current forward direction
        float angle = Vector3.Angle(initialForward, playerCamera.forward);

        // Target position when the player looks away
        Vector3 closePosition = playerCamera.position + playerCamera.forward * closeDistance;

        // Pause audio and move it closer if the player is looking back (angle > 120 degrees)
        if (angle > 90f && !isAudioPaused)
        {
            audioSource.Pause();
            isAudioPaused = true;
        }

        // Resume audio if the player turns back to face forward (angle < 120 degrees)
        else if (angle <= 120f && isAudioPaused)
        {
            audioSource.UnPause();
            isAudioPaused = false;
        }

        // Move the audio source smoothly based on whether the player is looking back or forward
        if (isAudioPaused)
        {
            // Move audio source towards the close position
            audioSourceTransform.position = Vector3.Lerp(audioSourceTransform.position, closePosition, Time.deltaTime * movementSpeed);
        }
        else
        {
            // Move audio source back to its original position
            audioSourceTransform.position = Vector3.Lerp(audioSourceTransform.position, initialAudioPosition, Time.deltaTime * movementSpeed);
        }
    }
}
