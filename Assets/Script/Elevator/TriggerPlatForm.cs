using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatForm : MonoBehaviour
{
    bool inReach;
    //public AudioSource elevator;
    public GameObject platformObject; // Reference to the GameObject that contains MoveingPlatForm
    MoveingPlatForm platForm;
    public Animator LeftDoor;
    public Animator RightDoor;
    public float delayBeforeMoving = 2f; // Exposed delay variable for flexibility
    public Collider triggerCollider; // To disable the collider after the audio sequence
    public GameObject triggerCollider2;
    void Start()
    {
        triggerCollider = GetComponent<Collider>();
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

        inReach = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            Debug.Log("In Reach");
            inReach = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false;
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            triggerCollider.enabled = true;
            triggerCollider2.SetActive(false);
            EDClose();
            StartCoroutine(DelayedAction());
        }
    }
    private IEnumerator DelayedAction()
    {
        Debug.Log("Starting delayed elevator movement.");
        yield return new WaitForSeconds(delayBeforeMoving);

        if (platForm != null)
        {
            platForm.canMove = true;
        }
        else
        {
            Debug.LogError("MoveingPlatForm reference is null!");
        }

        /*if (elevator != null)
         {
             //elevator.Play();
         }*/

        Debug.Log("Elevator should start moving.");
    }

    void EDClose()
    {
        if (LeftDoor != null && RightDoor != null)
        {
            LeftDoor.SetBool("Close", true);
            LeftDoor.SetBool("Open", false);
            RightDoor.SetBool("Close", true);
            RightDoor.SetBool("Open", false);
        }
        else
        {
            Debug.LogError("Animators for doors are missing!");
        }
    }
}
