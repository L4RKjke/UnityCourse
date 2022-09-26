using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnContinueButton()
    {
        _pauseButton.SetActive(true);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
    }
}