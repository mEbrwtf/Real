using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    public GameObject sneak;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        sneak.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
