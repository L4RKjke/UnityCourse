using UnityEngine;

public class PouseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;

    public void ShowPouseMenu()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePauseMenu()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
