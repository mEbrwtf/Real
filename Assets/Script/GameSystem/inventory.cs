using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform playerHand; // Reference to the player's hand transform
    private GameObject itemToPickup; // The item within reach to be picked up
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
        if (other.CompareTag("Item") && other.gameObject == itemToPickup)
        {
            itemToPickup = null; // Clear the item if it was the one being picked up
            Debug.Log("Item out of reach");
        }
    }

    void Update()
    {
        // Picking up an item
        if (itemToPickup != null && Input.GetButtonDown("USE") && heldItem == null) // Check if no item is currently held
        {
            PickUpItem(itemToPickup);
        }

        // Dropping the currently held item
        if (heldItem != null && Input.GetButtonDown("DROP"))
        {
            DropItem();
        }
    }

    void PickUpItem(GameObject item)
    {
        Debug.Log("Picked up: " + item.name);
        
        // Set the held item to the selected item and deactivate it in the world
        heldItem = item;
        
        // Remove Rigidbody to prevent physics effects while holding
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb); // Remove the Rigidbody component
        }

        // Make sure the item is active and visible in the player's hand
        heldItem.SetActive(true);

        // Parent the held item to the player's hand and reset its position and rotation
        heldItem.transform.SetParent(playerHand);
        heldItem.transform.localPosition = Vector3.zero; // Position correctly in hand
        heldItem.transform.localRotation = Quaternion.identity; // Reset rotation
    }

    void DropItem()
    {
        if (heldItem != null)
        {
            // Unparent the held item from the player's hand
            heldItem.transform.SetParent(null);

            // Add a Rigidbody for physics when the item is dropped
            Rigidbody rb = heldItem.AddComponent<Rigidbody>();

            // Position the item slightly in front of the player
            heldItem.transform.position = playerHand.position + playerHand.forward; // Position in front

            // Apply a force to simulate a natural drop
            rb.AddForce(playerHand.forward * 5 + Vector3.up * 2, ForceMode.Impulse);

            Debug.Log("Dropped: " + heldItem.name);
            
            // Clear the held item reference
            heldItem = null;
        }
    }
}
