using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerEnable : MonoBehaviour

{
    public AudioSource two;
    public Collider triggerCollider;
    public Collider NewtriggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        triggerCollider.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("triggerStart");
            two.Play();
            StartCoroutine(WaitForAudioToFinish());
        }
    }
    IEnumerator WaitForAudioToFinish()
    {
        yield return new WaitUntil(() => !two.isPlaying); // Wait until the audio finishes
        Debug.Log("audioIsntPlaying");
        waiting();
    }

    void waiting()
    {
        triggerCollider.enabled = false;
        NewtriggerCollider.enabled = true;
        Debug.Log("newtriggerStart");
        two.Play();
        // StartCoroutine(DelayedAction());
    }

    /*private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(22f);

    }
    // Update is called once per frame
    void Update()
    {
    }*/
}
