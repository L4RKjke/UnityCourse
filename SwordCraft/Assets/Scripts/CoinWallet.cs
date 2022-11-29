using UnityEngine;
using UnityEngine.Events;

public class CoinWallet : MonoBehaviour
{
    public UnityAction NewCoinEvent;

    public int Coins {get; private set; }

    public void AddCoin()
    {
        Coins++;
        NewCoinEvent?.Invoke();
    }
}
