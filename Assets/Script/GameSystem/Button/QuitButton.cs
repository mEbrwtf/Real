using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    public void QuitGame()
    {
        StartCoroutine(DelayedAction());
        Debug.Log("Game is exiting...");
    }

    private IEnumerator DelayedAction()
    {
        // Wait for 0.8 seconds
        yield return new WaitForSeconds(0.8f);

        // Perform the action after the delay
        Debug.Log("Action executed after delay!");
        Application.Quit();
    }
}

