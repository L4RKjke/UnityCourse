using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private GameObject _pauseButton;

    private void OnEnable()
    {
        _player.PlayerDie += OpenRestartPanel;
    }

    private void OnDisable()
    {
        _player.PlayerDie -= OpenRestartPanel;
    }

    private void OpenRestartPanel()
    {
        _pauseButton.SetActive(false);
        _restartPanel.SetActive(true);
    }

    public void OnRestartbuttonClick()
    {
        SceneManager.LoadScene(0);
    }
}
