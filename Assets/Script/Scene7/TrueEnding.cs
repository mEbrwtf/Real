using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEnding : MonoBehaviour
{
    public bool inReach;
    public AudioSource ring;
    public AudioSource pickup;
    public GameObject end;
    public Collider triggerCollider;

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
        }
    }
}
