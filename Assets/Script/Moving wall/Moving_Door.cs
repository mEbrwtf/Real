using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger : MonoBehaviour
{
    // Reference to the target object to move
    public Transform targetObject;

    // Reference to the Transform representing the target position
    public Transform targetPoint;

    // Speed of the movement
    public float moveSpeed = 1.0f;

    // Delay before starting the movement
    public float delay = 2.0f;

    // Boolean to track if the movement has already been triggered
    private bool isMoving = false;

    // Unity method for detecting trigger collisions
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player (you can use tags or other identifiers)
        if ((other.gameObject.tag == "Reach") && !isMoving)
        {
            // Start the coroutine to delay the movement
            StartCoroutine(MoveObjectWithDelay());
        }
    }

    // Coroutine to handle the delayed movement
    private IEnumerator MoveObjectWithDelay()
    {
        // Mark the movement as initiated
        isMoving = true;

        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Move the object to the target position
        yield return StartCoroutine(MoveToPosition());

        // Reset the movement flag if needed (commented out if you want it to trigger only once)
        // isMoving = false;
    }

    // Coroutine to move the object to the target position
    private IEnumerator MoveToPosition()
    {
        // Continue moving until the object reaches the target position
        while (Vector3.Distance(targetObject.position, targetPoint.position) > 0.01f)
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, targetPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure the object ends up exactly at the target position
        targetObject.position = targetPoint.position;
    }
}