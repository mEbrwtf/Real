using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public Collider Object1;
    public Collider Object2;
    // Start is called before the first frame update
    void Start()
    {
        Object1.enabled = false;
        Object2.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Object1.enabled = true;
            Object2.enabled = true;
        }
    }
}