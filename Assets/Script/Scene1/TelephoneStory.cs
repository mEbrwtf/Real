using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneStory : MonoBehaviour
{
    AudioSource ring;
    public AudioSource PickUp;
    public AudioSource BossCall;
    public bool inReach = false;
    public AudioSource one;
    public Collider collision;
    // Start is called before the first frame update
    void Start()
    {
        collision.enabled = false;
        Debug.Log("TriggerUneable");
        ring = GetComponent<AudioSource>();
        ring.Play();
        Debug.Log("ringing");
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
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("PickUp"))
        {
            Answer();
        }
    }
    void Answer()
    {
        ring.Stop();
        Debug.Log("Hanging out");
        PickUp.Play();
        StartCoroutine(DelayedAction());
    }
    private IEnumerator DelayedAction()
    {
        // Wait for 0.8 seconds
        yield return new WaitForSeconds(1f);
        BossCall.Play();
        yield return new WaitForSeconds(22f);
        Debug.Log("It's been 22s");
        collision.enabled = true;
        Debug.Log("Trigger enabled");
    }
}
