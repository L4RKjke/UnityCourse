using UnityEngine;

public class MenuButtonsController : MonoBehaviour
{ 
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _swords;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private Shop _shop;

    public void OnExitButton()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void OnOptionsButton()
    {
        _optionsPanel.SetActive(true);
    }

    public void OnShopButton()
    {
        _shopPanel.SetActive(true);
        _shop.enabled = true;
    }

    public void OnExitSettingsButton()
    {
        _optionsPanel.SetActive(false);
        PlayerPrefs.SetFloat(AllStrings.MusicVolume, _audioController.Volume);
        PlayerPrefs.Save();
    }

    public void OnSwordsButtonClick()
    {
        _swords.SetActive(true);
    }

    public void OnExitSwordsButtonClick()
    {
        _swords.SetActive(false);
    }

    public void OnExitShopButton()
    {
        _shopPanel.SetActive(false);
        _shop.enabled = false;
    }
}

