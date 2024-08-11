using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu UI

    private bool isPaused = false;

    void Update()
    {
        // Toggle pause when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Button Clicked!"); // Add this line
        pauseMenuUI.SetActive(false); // Hide the resume menu
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void OnLeaveButtonPressed()
    {
        // Load the next scene (replace "SceneName" with your scene's name)
        SceneManager.LoadScene("MainMenu");
    }
}
