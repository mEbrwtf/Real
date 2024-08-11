using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveButton : MonoBehaviour
{
    public void OnLeaveButtonPressed()
    {
        Time.timeScale = 1f; // Ensure the game is running at normal speed
        // Load the next scene (replace "SceneName" with your scene's name)
        SceneManager.LoadScene(1);
        
    }
}
