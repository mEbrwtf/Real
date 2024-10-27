using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTag : MonoBehaviour
{
    public bool inReach;
    public GameObject IsawIt;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("tagReach");
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
            IsawIt.SetActive(true);
        }
    }
}
