using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticCloseDoor : MonoBehaviour
{
    public Animator door;
    public Collider triggerCollider;
    public GameObject Previous;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetBool("Close", true);
            Previous.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            Debug.Log("DoorClosed");
            triggerCollider.enabled = false;
            Debug.Log("Trigger enable");
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
