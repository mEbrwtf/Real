using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public AudioSource doorOpen;
    public AudioSource doorClose;

    bool inReach;
    public Animator LeftDoor;
    public Animator RightDoor;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach");
            inReach = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            EDopen();
            StartCoroutine(DelayedAction());
        }
    }
    public void EDopen()
    {
        doorOpen.Play();
        LeftDoor.SetBool("Open", true);
        LeftDoor.SetBool("Close", false);
        RightDoor.SetBool("Open", true);
        RightDoor.SetBool("Close", false);
    }
    public void EDclose()
    {
        doorClose.Play();
        LeftDoor.SetBool("Close", true);
        LeftDoor.SetBool("Open", false);
        RightDoor.SetBool("Close", true);
        RightDoor.SetBool("Open", false);
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(6f);
        EDclose();
    }
}