using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButtonSettings : MonoBehaviour
{
    [SerializeField] private GameObject[] _lvlButtons;
    [SerializeField] private TextMeshProUGUI _txtMPro;
    [SerializeField] private Shop _shop;

    private int _completedLevels;

    private void OnEnable()
    {
        _shop.UpdateCoinEvent += UpdateCoinsText;
    }

    private void OnDisable()
    {
        _shop.UpdateCoinEvent -= UpdateCoinsText;
    }

    private void Start()
    {
        UpdateCoinsText();

        for (int i = 1; i < _lvlButtons.Length; i++)
        {
            if (_lvlButtons[i].TryGetComponent(out Button button))
                button.interactable = false;
        }

        _completedLevels = PlayerPrefs.GetInt(AllStrings.MaxLevel);

        for (int i = 1; i < _completedLevels + 1; i++)
        {
            ActivateNewLevel(i);
        }
    }

    public void ActivateNewLevel(int levelIndex)
    {
        if (_lvlButtons[levelIndex].TryGetComponent(out Button button) && _lvlButtons[levelIndex].TryGetComponent(out LevelUIController levelUIController))
        {
            button.interactable = true;
            levelUIController.DeleteLock();
        }

    }

    private void UpdateCoinsText()
    {
        _txtMPro.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
