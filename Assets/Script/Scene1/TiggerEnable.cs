using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerEnable : MonoBehaviour

{
    public AudioSource two;
    public Collider triggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            two.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
