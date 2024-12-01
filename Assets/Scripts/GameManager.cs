using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance of the GameManager
    public static GameManager Instance;

    // Flag to check if the game is over
    public bool gameOver;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If no instance of GameManager exists, set this one as the instance
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the gameOver flag to false
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // (Optional) This is where you can add code that needs to run every frame
    }

    // Method to start the game
    public void StartGame()
    {
        // Notify the UI Manager to start the game UI
        UiManager.instance.GameStart();

        // Start tracking the score
        ScoreManager.instance.StartScore();

        // Find the PlatformSpawner object and start spawning platforms
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawnner>().StartPlatformSpawnnig();
    }

    // Method to handle game over logic
    public void GameOver()
    {
        // Notify the UI Manager to display the game over UI
        UiManager.instance.GameOver();

        // Stop tracking the score
        ScoreManager.instance.StopScore();

        // Set the gameOver flag to true
        gameOver = true;
    }
}
