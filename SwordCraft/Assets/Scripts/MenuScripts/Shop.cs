using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] _buyButtons;
    [SerializeField] private GameObject[] _selectButtons;
    [SerializeField] private Background[] _backgrounds;

    public UnityAction UpdateCoinEvent;

    private void OnEnable()
    {
        for (int i = 1; i < _buyButtons.Length; i++)
        {
            _buyButtons[i].GetComponent<Button>().interactable = true;
            _selectButtons[i].GetComponent<Button>().interactable = false;

            if (PlayerPrefs.GetString((AllStrings.Background + i.ToString())) == AllStrings.HasBought)
            {
                _buyButtons[i].GetComponent<Button>().interactable = false;
                _selectButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnSelectButtonClick(int buttonId)
    {
        PlayerPrefs.SetInt(AllStrings.CurrentBackground, buttonId);
    }

    public void OnBuyButtonClick(int buttonId)
    {
        if (PlayerPrefs.GetInt(AllStrings.Coins) >= _backgrounds[buttonId].Price)
        {
            if (_buyButtons[buttonId].TryGetComponent(out Button buyButton) && _selectButtons[buttonId].TryGetComponent(out Button selectButton))
            {
                buyButton.interactable = false;
                selectButton.interactable = true;
            }

            PlayerPrefs.SetInt(AllStrings.Coins, PlayerPrefs.GetInt(AllStrings.Coins) - _backgrounds[buttonId].Price);
            PlayerPrefs.SetString((AllStrings.Background + buttonId.ToString()), AllStrings.HasBought);
            UpdateCoinEvent?.Invoke();
        }
    }
}
