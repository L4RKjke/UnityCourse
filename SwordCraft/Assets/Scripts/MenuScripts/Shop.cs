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

            if (PlayerPrefs.GetString(("Background" + i.ToString())) == "HasBought")
            {
                _buyButtons[i].GetComponent<Button>().interactable = false;
                _selectButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnSelectButtonClick(int buttonId)
    {
        PlayerPrefs.SetInt("CurrentBackground", buttonId);
    }

    public void OnBuyButtonClick(int buttonId)
    {
        if (PlayerPrefs.GetInt("Coins") >= _backgrounds[buttonId].Price)
        {
            if (_buyButtons[buttonId].TryGetComponent(out Button buyButton) && _selectButtons[buttonId].TryGetComponent(out Button selectButton))
            {
                buyButton.interactable = false;
                selectButton.interactable = true;
            }

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - _backgrounds[buttonId].Price);
            PlayerPrefs.SetString(("Background" + buttonId.ToString()), "HasBought");
            UpdateCoinEvent?.Invoke();
        }
    }
}
