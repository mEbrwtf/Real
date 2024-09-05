using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator_Pack : MonoBehaviour
{
    public AudioSource narrator1;
    public AudioSource narrator2;
    public GameObject sitting;

    // Start is called before the first frame update
    void Start()
    {
        narrator1.Play();
        StartCoroutine(DelayedAction());
        sitting.SetActive(true);
    }

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(5f);
        narrator2.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
