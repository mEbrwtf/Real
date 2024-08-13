using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class when : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DelayedAction());
    }

    private IEnumerator DelayedAction()
    {
        // Wait for 8 seconds
        yield return new WaitForSeconds(59f);
        Debug.Log("Action executed after delay!");
        SceneManager.LoadScene("Scene 1");
    }
}
