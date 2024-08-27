using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject currentTrigger;
    public GameObject nextTrigger;
    public AudioSource audioSource;
    public AudioSource LastaudioSource;
    void Start()
    {
        audioSource.Stop();
        nextTrigger.SetActive(false);
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
            nextTrigger.SetActive(true);
            currentTrigger.SetActive(false);
        }
    }

}