using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToScene1 : MonoBehaviour
{
    public Image black;
    public Animator fade;
    public bool isNextScene = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        fade.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Scene 1");
    }
}
