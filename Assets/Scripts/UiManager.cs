using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Singleton instance of UiManager
    public static UiManager instance;

    // UI elements
    public GameObject zigzagPanel;        // Panel displayed at the start of the game
    public GameObject gameOverPanel;      // Panel displayed when the game is over
    public GameObject tapText;            // Text instructing the player to tap to start
    public TMP_Text scoreText;            // Text to display the current score
    public TMP_Text highscoreText1;       // Text to display the high score on the game over panel
    public TMP_Text highscoreText2;       // Text to display the high score on the start panel

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If no instance of UiManager exists, set this one as the instance
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Display the high score on the start panel using PlayerPrefs
        highscoreText2.text = "High Score:   " + PlayerPrefs.GetInt("highscore").ToString();
    }

    // Method to handle the start of the game
    public void GameStart()
    {
        // Hide the tap to start text
        tapText.SetActive(false);

        // Play the start animation for the zigzag panel
        zigzagPanel.GetComponent<Animator>().Play("Panel");
    }

    // Method to handle the game over scenario
    public void GameOver()
    {
        // Display the current score using PlayerPrefs
        scoreText.text = PlayerPrefs.GetInt("score").ToString();

        // Display the high score on the game over panel using PlayerPrefs
        highscoreText1.text = PlayerPrefs.GetInt("highscore").ToString();

        // Show the game over panel
        gameOverPanel.SetActive(true);

        // Play the game over animation on the game over panel
        gameOverPanel.GetComponent<Animator>().Play("GameOver");
    }

    // Method to reset the game
    public void GameReset()
    {
        // Reload the scene (typically used to restart the game)
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        // (Optional) This is where you can add code that needs to run every frame
    }
}
