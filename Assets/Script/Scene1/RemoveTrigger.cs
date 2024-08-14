using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    public Collider triggerCollider;

    void Start()
    {
        // Get the Collider component
        triggerCollider = GetComponent<Collider>();

        // Ensure the GameObject has a Collider component and it's set as a trigger
        if (triggerCollider == null)
        {
            triggerCollider = gameObject.AddComponent<BoxCollider>();
            triggerCollider.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // You can add any functionality here for when the player enters the trigger
            Debug.Log("Player entered the trigger.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Disable the trigger to prevent further triggering
            triggerCollider.enabled = false; // Remove the trigger when the player exits
            Debug.Log("Trigger removed after player exit.");
        }
    }
}
