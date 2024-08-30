using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotAnswer : MonoBehaviour
{
    public AudioSource audioSource1;
    public GameObject sub1;
    public AudioSource audioSource2;
    public GameObject sub2;

    public AudioSource audioSource3;
    public GameObject sub3;

    public GameObject Tele;
    public AudioSource Hang_up;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DelayedAction());
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(8f);
        audioSource1.Play();
        sub1.SetActive(true);
        yield return new WaitForSeconds(5f);
        sub1.SetActive(false);
        yield return new WaitForSeconds(10f);
        audioSource2.Play();
        sub2.SetActive(true);
        yield return new WaitForSeconds(3f);
        sub2.SetActive(false);
        yield return new WaitForSeconds(1f);
        audioSource3.Play();
        sub3.SetActive(true);
        yield return new WaitForSeconds(1f);
        sub3.SetActive(false);
        yield return new WaitForSeconds(3f);
        Tele.SetActive(false);
        Hang_up.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
