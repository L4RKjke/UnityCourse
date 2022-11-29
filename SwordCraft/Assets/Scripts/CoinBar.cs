using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class CoinBar : MonoBehaviour
{
    [SerializeField] private CoinWallet _wallet;
    [SerializeField] private int _maxCoins;

    private TextMeshProUGUI _txtMPro;

    private void OnEnable()
    {
        _wallet.NewCoinEvent += UpdateCoinBar;
    }

    private void OnDisable()
    {
        _wallet.NewCoinEvent -= UpdateCoinBar;
    }

    private void Start()
    {
        _txtMPro = transform.GetComponent<TextMeshProUGUI>();
        _txtMPro.text = (_wallet.Coins + "\\" + _maxCoins);
    }

    private void UpdateCoinBar()
    {
        _txtMPro.text = (_wallet.Coins + "\\" + _maxCoins);
    }
}
