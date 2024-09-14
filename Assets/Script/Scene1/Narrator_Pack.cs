using System.Collections;
using UnityEngine;

public class Narrator_Pack : MonoBehaviour
{
    public AudioSource narrator1;
    public AudioSource narrator2;
    public GameObject sitting;

    void Start()
    {
        sitting.SetActive(true);
        narrator1.Play();
        StartCoroutine(PlaySecondNarrator());
    }

    private IEnumerator PlaySecondNarrator()
    {
        yield return new WaitForSeconds(5f);
        narrator2.Play();
    }
}
