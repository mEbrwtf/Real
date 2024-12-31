using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractHighlight : MonoBehaviour
{
    public GameObject unhighlight;
    public GameObject highlight;
    bool inReach;
    public GameObject display_Text;
    public GameObject Dot;

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
            display_Text.SetActive(true);
            Dot.SetActive(false);
            highlight.SetActive(true);
            unhighlight.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
            display_Text.SetActive(false);
            Dot.SetActive(true);
            highlight.SetActive(false);
            unhighlight.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("USE"))
        {
            display_Text.SetActive(false);
            Dot.SetActive(true);
            highlight.SetActive(false);
            unhighlight.SetActive(true);
        }
    }
}
