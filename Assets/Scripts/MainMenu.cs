using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu controller for scene navigation
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the main game scene (assumes it's at index 1)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
