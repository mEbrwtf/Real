using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHighlight : MonoBehaviour
{
    public GameObject unhighlight;
    public GameObject highlight;
    bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        highlight.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            highlight.SetActive(true);
            unhighlight.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
            highlight.SetActive(false);
            unhighlight.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("USE"))
        {
            highlight.SetActive(false);
            unhighlight.SetActive(true);
        }
    }
}
