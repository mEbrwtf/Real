using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnactiveTriggrer : MonoBehaviour
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
            Trigger.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
