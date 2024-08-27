using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneStory : MonoBehaviour
{
    public Collider Phone;
    AudioSource ring;
    public AudioSource PickUp;
    public AudioSource BossCall;
    public bool inReach = false;
    public AudioSource one;
    public GameObject collision;
    public GameObject script;
    public Animator door;

    // Start is called before the first frame update
    void Start()
    {
        door.enabled = false;
        collision.SetActive(false);
        ring = GetComponent<AudioSource>();
        ring.Play();
        Debug.Log("ringing");
        script.SetActive(true);
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

        // Disable the collider to prevent further interaction
        Phone.enabled = false;
        inReach = false;
        script.SetActive(false);

        StartCoroutine(DelayedAction());
    }
    private IEnumerator DelayedAction()
    {

        // Wait for 0.8 seconds
        yield return new WaitForSeconds(1f);
        BossCall.Play();
        yield return new WaitForSeconds(22f);
        Debug.Log("It's been 22s");
        collision.SetActive(true);
        Debug.Log("Trigger enabled");
        door.enabled = true;

    }
}

