using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coinGoal = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            CollectCoin(coin);
        }
    }

    public void DestoyEntity()
    {
        Destroy(gameObject);
    }

    private void CollectCoin(Coin coin)
    {
        coin.DestoyEntity();
        _coinGoal -= 1;
    } 

}
