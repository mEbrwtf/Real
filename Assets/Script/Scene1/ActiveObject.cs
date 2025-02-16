using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    public GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trigger.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
