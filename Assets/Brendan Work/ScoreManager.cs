using TMPro; // Add this for TextMeshPro support
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Change from Text to TextMeshProUGUI
    public TextMeshProUGUI highScoreText; // Same for high score text
    public float distanceTraveled = 0f; // Distance traveled
    public float speed = 5f; // Movement speed of the player
    private float highScore = 0f;

    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
    }

    void Update()
    {
        // Update distance based on speed
        distanceTraveled += speed * Time.deltaTime;
        scoreText.text = "Score: " + Mathf.RoundToInt(distanceTraveled).ToString();

        // Update high score if the current score is greater
        if (distanceTraveled > highScore)
        {
            highScore = distanceTraveled;
            PlayerPrefs.SetFloat("HighScore", highScore);
            highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
        }
    }
}

