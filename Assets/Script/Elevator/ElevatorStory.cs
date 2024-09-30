using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorStory : MonoBehaviour
{
    //public AudioSource elevator;
    public GameObject platformObject; // Reference to the GameObject that contains MoveingPlatForm

    MoveingPlatForm platForm;
    //public Animator LeftDoor;
    //public Animator RightDoor;
    //public float delayBeforeMoving = 2f; // Exposed delay variable for flexibility

    void Start()
    {
        if (platformObject != null)
        {
            platForm = platformObject.GetComponent<MoveingPlatForm>();
            if (platForm == null)
            {
                Debug.LogError("MoveingPlatForm component is missing on the assigned GameObject!");
            }
        }
        else
        {
            Debug.LogError("Platform Object not assigned in the inspector!");
        }

        /*if (elevator == null)
        {
            Debug.LogError("AudioSource for elevator is missing!");
        }*/

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stay");
            platForm.canMove = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In Reach");
        }
    }

    void Update()
    {
    }
}
