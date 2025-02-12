using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public AudioSource DoorS;
    public Animator Door;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in");
            Door.SetBool("Close", true);
            Door.SetBool("Open", false);
            Door.SetBool("Closed", false);
            DoorS.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
