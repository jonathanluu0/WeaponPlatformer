using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Assign a UI Text element for score
    public Text highScoreText; // Assign a UI Text element for high score
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

