using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToEnding : MonoBehaviour
{
    public Image black;
    public Animator fade;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fading());
        }
        else if (other.CompareTag("Super Player"))
        {
            StartCoroutine(Fading2());
        }
    }

    IEnumerator Fading()
    {
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Scene 1");
    }
    IEnumerator Fading2()
    {
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("ToEnding(1)");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
