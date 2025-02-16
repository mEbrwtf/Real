using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttton : MonoBehaviour
{
    public Animator button;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            button.SetBool("Up", true);
        }
    }
}
