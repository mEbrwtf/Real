using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActive : MonoBehaviour
{
    public Animator Wall;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in");
            Wall.SetBool("Up", true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
