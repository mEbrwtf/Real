using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject music;
    //public AudioSource nar;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MusicDelay());
            //nar.Play();
        }
    }    // Update is called once per fram
    void OnTriggerExit(Collider other)
    {

    }
    private IEnumerator MusicDelay()
    {
        yield return new WaitForSeconds(3);
        music.SetActive(true);

    }
    void Update()
    {

    }
}
