using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator door;
    public bool inReach;
    public AudioSource openSound;
    public AudioSource closeSound;

    private bool isOpen = false; // Track door state
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedAction());
        }
    }
    // Update is called once per frame

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(2f);
        door.SetBool("Open", true);
        door.SetBool("Closed", false);


    }
}
