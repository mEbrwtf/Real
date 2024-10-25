using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform playerHand; // Reference to the player's hand transform
    private GameObject itemToPickup; // Current item selected for pickup
    private GameObject heldItem; // The item currently held by the player

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemToPickup = other.gameObject; // Set the current item to pickup
            Debug.Log("Item in reach: " + itemToPickup.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.gameObject == itemToPickup)
            {
                itemToPickup = null; // Clear the item if it was the one being picked up
            }
            Debug.Log("Item out of reach");
        }
    }

    void Update()
    {
        // Picking up an item
        if (itemToPickup != null && Input.GetButtonDown("USE"))
        {
            if (heldItem == null) // Check if no item is currently held
            {
                PickUpItem(itemToPickup);
            }
        }

        // Dropping the currently held item
        if (heldItem != null && Input.GetButtonDown("DROP"))
        {
            DropItem();
        }
    }

    void PickUpItem(GameObject item)
    {
        // Deactivate the original item in the scene
        item.SetActive(false);
        Debug.Log("Picked up: " + item.name);
        
        // Set the held item to the original item
        heldItem = item; // Directly reference the item
        
        // Parent the held item to the player's hand and position it
        heldItem.transform.SetParent(playerHand);
        heldItem.transform.localPosition = Vector3.zero; // Position it correctly in hand
        heldItem.transform.localRotation = Quaternion.identity; // Reset rotation
    }

    void DropItem()
    {
        if (heldItem != null)
        {
            // Unparent the held item from the player's hand
            heldItem.transform.SetParent(null);

            // Add a Rigidbody if it doesn't already have one
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = heldItem.AddComponent<Rigidbody>(); // Add Rigidbody component if it doesn't exist
            }

            // Position the item in front of the player and make it active
            heldItem.transform.position = playerHand.position + playerHand.forward; // Position it in front of the player
            heldItem.SetActive(true); // Ensure the item is active in the world

            // Apply some upward force to give it a little push
            rb.AddForce(playerHand.forward * 7, ForceMode.Impulse);

            Debug.Log("Dropped: " + heldItem.name);
            heldItem = null; // Clear the held item reference
        }
    }
}
