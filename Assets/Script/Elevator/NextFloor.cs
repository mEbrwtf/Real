using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloor : MonoBehaviour
{
    public Animator LeftDoor;
    public Animator RightDoor;
    public Collider doorTrigger; // To reference the trigger's collider
    // Start is called before the first frame update
    void Start()
    {
        doorTrigger = GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Inside");
            StartCoroutine(DelayedOpen());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Outside");
            doorTrigger.enabled = false;
            StartCoroutine(DelayedClose());
        }
    }
    private IEnumerator DelayedOpen()
    {
        yield return new WaitForSeconds(2f);
        EDopen();
        yield return new WaitForSeconds(6f);
        EDclose();
    }
    private IEnumerator DelayedClose()
    {
        yield return new WaitForSeconds(6f);
        EDclose();
    }
    public void EDopen()
    {
        LeftDoor.SetBool("Open", true);
        LeftDoor.SetBool("Close", false);
        RightDoor.SetBool("Open", true);
        RightDoor.SetBool("Close", false);
    }
    public void EDclose()
    {
        LeftDoor.SetBool("Close", true);
        LeftDoor.SetBool("Open", false);
        RightDoor.SetBool("Close", true);
        RightDoor.SetBool("Open", false);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
