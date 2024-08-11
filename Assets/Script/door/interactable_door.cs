using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable_door : MonoBehaviour
{
    public Animator door;
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
            DoorOpens();
        }

        else
        {
            DoorCloses();
        }
    }

   void DoorOpens()
    {
        Debug.Log("It's Opens");
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }

    void DoorCloses()
    {
        //Debug.Log("It's Closes");
        door.SetBool("Open", false);
        door.SetBool("Close", true);
    }


}
