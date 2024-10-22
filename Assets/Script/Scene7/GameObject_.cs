using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_ : MonoBehaviour
{
    public GameObject here;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        here.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
