using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Collider Self;
    public Animator wall;
    public Animator buttonA;
    bool inReach;
    public GameObject wow;

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            Debug.Log("Button in reach!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            wow.SetActive(true);
            ButtonClick();
        }
    }

    void ButtonClick()
    {
        wall.SetBool("Down", true);
        buttonA.SetBool("A", true);
        Self.enabled = false;
    }
}
