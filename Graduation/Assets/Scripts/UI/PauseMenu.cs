using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnContinueButton()
    {
        Time.timeScale = 1f; ;
        gameObject.SetActive(false);
    }
}