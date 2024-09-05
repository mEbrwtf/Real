using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitting : MonoBehaviour
{
    public Camera mainCamera;
    public Camera sittinCamera;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        sittinCamera.enabled = false;
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
            Debug.Log("In Reach");
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("PickUp"))
        {
            SittingDown();
        }
    }
    void SittingDown()
    {
        mainCamera.enabled = false;
        sittinCamera.enabled = true;
    }
}
