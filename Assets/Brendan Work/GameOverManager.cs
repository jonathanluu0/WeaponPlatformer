using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Game Test"); // **Replace with your actual game scene name**
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Menu"); // **Replace with your main menu scene name**
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in Unity Editor
#endif
    }
}
