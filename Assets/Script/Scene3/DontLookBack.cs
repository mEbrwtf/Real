using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLookBack : MonoBehaviour
{
    public bool inReach;
    public GameObject object1;
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {
        object2.SetActive(false);
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
        if (inReach)
        {
            object1.SetActive(false);
            object2.SetActive(true);

        }
    }
}
