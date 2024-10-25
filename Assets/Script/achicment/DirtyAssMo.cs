using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyAssMo : MonoBehaviour
{
    public GameObject ach;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            ach.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
