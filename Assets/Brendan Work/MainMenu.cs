using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start Game button functionality
    public void StartGame()
    {
        // Load the next scene (ensure your game scene is added in the Build Settings)
        SceneManager.LoadScene("Game Test"); // Replace "GameScene" with your actual game scene name
    }

    // Options button functionality
    public void OpenOptions()
    {
        // For now, just log to the console
        Debug.Log("Options Menu clicked!");
        // You can implement your options menu logic here
    }

    // Quit button functionality
    public void QuitGame()
    {
        Debug.Log("Quit Game clicked!");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quit the application when running a build
            Application.Quit();
        #endif
    }
}
