using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public Collider currentTrigger;
    public Collider nextTrigger;
    public AudioSource audioSource;
    public AudioSource LastaudioSource;
    void Start()
    {
        audioSource.Stop();
        nextTrigger.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            LastaudioSource.Stop();
        }
        /*if (!audioSource.isPlaying)
        {
            currentTrigger.SetActive(false);
            nextTrigger.SetActive(true);
        }*/
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextTrigger.enabled = true;
            currentTrigger.enabled = false;
        }
    }

}