using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotKey : MonoBehaviour
{
    public GameObject ReKey;
    public GameObject Talk;
    public Collider trigger;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        trigger.enabled = false;
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
        if (inReach && Input.GetButtonDown("USE"))
        {
            trigger.enabled = true;
            ReKey.SetActive(true);
            Talk.SetActive(false);
        }
    }
}
