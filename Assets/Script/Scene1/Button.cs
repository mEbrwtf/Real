using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator wall;
    bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            Debug.Log("Button!");
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            ButtonClick();
        }
    }
    void ButtonClick()
    {
        wall.SetBool("Down", true);
    }
}
