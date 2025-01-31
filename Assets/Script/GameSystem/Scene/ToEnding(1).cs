using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToEnding : MonoBehaviour
{
    public GameObject timeline;
    //public Image black;
    //public Animator fade;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.SetActive(true);
            StartCoroutine(Fading2());
        }
    }
    IEnumerator Fading2()
    {
        yield return new WaitForSeconds(10f);
        //fade.SetBool("Fade", true);
        SceneManager.LoadScene("Ending(1)");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
