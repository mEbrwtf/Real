using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitting : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject sittinCamera;
    public GameObject SecChan;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.SetActive(true);
        sittinCamera.SetActive(false);
        inReach = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach");
            inReach = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach");
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("USE"))
        {
            StartCoroutine(DelayedAction());
            SittingDown();
        }
        if (Input.GetButtonDown("OUT"))
        {
            StandingUp();
        }
    }
    void SittingDown()
    {
        mainCamera.SetActive(false);
        sittinCamera.SetActive(true);
    }
    void StandingUp()
    {
        mainCamera.SetActive(true);
        sittinCamera.SetActive(false);
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(20f);
        SecChan.SetActive(true);
    }
}
