using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
    private int _sceneIndex;

    private readonly int _menuIndex = 0;

    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneIndex+1);
    }

    public void LoadCurrentLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_menuIndex);
    }
}