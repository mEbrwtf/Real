using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTag : MonoBehaviour
{
    public bool inReach;
    public GameObject IsawIt;
    public Collider tag;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        tag.enabled = false;
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
        if (inReach)
        {
            IsawIt.SetActive(true);
        }
    }
}
