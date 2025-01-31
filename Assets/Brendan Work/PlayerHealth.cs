using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import SceneManager

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts; // UI heart images
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool isDead = false; // Prevent multiple deaths

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Prevent taking damage after death

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    void GameOver()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Game Over! Loading Game Over Scene...");

        // **2. Load Game Over Scene after delay**
        Invoke("LoadGameOverScene", 1.5f); // Wait 1.5 seconds before switching scenes
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over"); // **Replace with your actual Game Over scene name**
    }
}
