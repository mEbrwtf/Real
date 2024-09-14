using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class two : MonoBehaviour
{
    public AudioSource one;
    public Collider own;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            one.Play();
            StartCoroutine(DelayedAction());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
        }
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(8);
        Button.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
