using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    
    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
    }

    private void Start()
    {
        // Make sure the game over panel is hidden at the start
        gameOverPanel.SetActive(false);
        
        // Add listener to the restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnPlayerDeath()
    {
        // Show the game over panel
        gameOverPanel.SetActive(true);
        
        // Unlock and show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        // Optionally pause the game
        Time.timeScale = 0f;
    }

    private void RestartGame()
    {
        // Reset time scale
        Time.timeScale = 1f;
        
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}