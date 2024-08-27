using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantUseDoor : MonoBehaviour
{
    public Collider door;
    public AudioSource audioSource;
    public bool inReach;
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
            CanUse();
        }
    }
    void CanUse()
    {
        audioSource.Play();

        inReach = false;
        door.enabled = false;
    }
}
