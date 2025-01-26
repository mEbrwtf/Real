using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    public Image black;
    public Animator fade;
    public GameObject sleep;
    public GameObject Notsleep;
    public bool isNextScene = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Notsleep.SetActive(false);
            sleep.SetActive(true);
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(3f);
        fade.SetBool("Fade", true);
        SceneManager.LoadScene("Scene 1");
    }
}
