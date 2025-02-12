using System.Collections;
using UnityEngine;

public class GotKey : MonoBehaviour
{
    public GameObject ReKey;
    public GameObject Talk;
    public GameObject trigger;
    public bool inReach;

    void Start()
    {
        trigger.SetActive(true);
        Talk.SetActive(false);
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
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
            //StartCoroutine(PickUpKey());
            trigger.SetActive(true);
            ReKey.SetActive(true);
            Talk.SetActive(false);
        }

        if (Input.GetButtonDown("DROP"))
        {
            //StartCoroutine(DropKey());
            trigger.SetActive(false);
            ReKey.SetActive(false);
            Talk.SetActive(true);
        }
    }

    /*private IEnumerator PickUpKey()
    {
        yield return new WaitForSeconds(0f); // Adjust if needed

    }

    private IEnumerator DropKey()
    {
        yield return new WaitForSeconds(0f); // Adjust if needed

    }*/
}
