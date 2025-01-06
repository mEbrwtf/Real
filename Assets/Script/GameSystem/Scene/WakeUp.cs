using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    //public GameObject player;
    public GameObject splayer;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player.SetActive(false);
            splayer.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
