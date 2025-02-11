using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActive : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnterTrigger(Collider other)
    {
        if (other.CompareTag("Player")){
            wall.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
