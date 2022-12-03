using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    [SerializeField] private GameObject _sceneLoader;

    private int _sceneId;

    public int SceneId => _sceneId;

    public void LoadScene(int numberOfScene)
    {
        SceneManager.LoadScene(numberOfScene);
    }
}