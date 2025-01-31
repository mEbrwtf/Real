using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nding : MonoBehaviour
{
    public GameObject Ending;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        Ending.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
