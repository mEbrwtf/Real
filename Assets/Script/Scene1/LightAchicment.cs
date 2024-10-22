using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAchicment : MonoBehaviour
{
    public bool inReach;
    public AudioSource com;

    // Start is called before the first frame update
    void Start()
    {
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
            com.Play();
        }
    }
}
