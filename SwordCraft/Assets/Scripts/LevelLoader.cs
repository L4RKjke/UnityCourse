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
        SceneManager.LoadScene(_sceneIndex+1);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_menuIndex);
    }
}