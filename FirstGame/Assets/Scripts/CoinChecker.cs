using UnityEngine;

public class CoinChecker : MonoBehaviour
{
    [SerializeField] private int _coinGoal = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.DestoyEntity();
            _coinGoal -= 1;
        }
    }
}