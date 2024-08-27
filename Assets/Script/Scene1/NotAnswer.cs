using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAnswer : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedAction());
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(8f);
        audioSource1.Play();
        yield return new WaitForSeconds(14f);
        audioSource2.Play();
        yield return new WaitForSeconds(16f);
        audioSource3.Play(); 
    }
    // Update is called once per frame
    void Update()
    {

    }
}
