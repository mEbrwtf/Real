using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button!");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
