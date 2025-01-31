using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Animator door;

    // Start is called before the first frame update
    void Start()
    {
    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetBool("Closed", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
