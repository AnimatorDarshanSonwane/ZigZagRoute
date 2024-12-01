using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton instance of the ScoreManager
    public static ScoreManager instance;

    // Variables to store the current score and high score
    public int score;
    public int highscore;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If no instance of ScoreManager exists, set this one as the instance
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score in PlayerPrefs
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        // (Optional) This is where you can add code that needs to run every frame
    }

    // Method to increment the score
    void incrementScore()
    {
        // Increase the score by 1
        score += 1;
    }

    // Method to start the score incrementing process
    public void StartScore()
    {
        // Repeatedly call incrementScore every 0.5 seconds, starting after 0.1 seconds
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    // Method to stop the score incrementing process
    public void StopScore()
    {
        // Cancel the repeating calls to incrementScore
        CancelInvoke("incrementScore");

        // Save the current score in PlayerPrefs
        PlayerPrefs.SetInt("score", score);

        // Check if there is a saved high score
        if (PlayerPrefs.HasKey("highscore"))
        {
            // If the current score is higher than the saved high score, update it
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            // If there is no saved high score, set the current score as the high score
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
