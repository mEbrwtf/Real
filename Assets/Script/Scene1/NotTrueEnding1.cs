using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotTrueEnding1 : MonoBehaviour
{
    public bool inReach;
    public AudioSource ring;
    public AudioSource pickup;
    public GameObject end;
    public GameObject notpickup;
    public Collider door;
    public Collider triggerCollider;
    private Coroutine delayedActionCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider>();
        ring.Play();
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
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
            ring.Stop();
            pickup.Play();
            end.SetActive(true);
            door.enabled = true;

            if (delayedActionCoroutine != null)
            {
                StopCoroutine(delayedActionCoroutine);
                delayedActionCoroutine = null;
            }
        }
        else if (!(inReach && Input.GetButtonDown("Click")))
        {
            if (delayedActionCoroutine == null)
            {
                delayedActionCoroutine = StartCoroutine(DelayedAction());
            }
        }
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(20f);
        ring.Stop();
        pickup.Stop();
        triggerCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        delayedActionCoroutine = null;
        //NotPickUp();
    }
    void NotPickUp()
    {
        notpickup.SetActive(true);
    }

}
