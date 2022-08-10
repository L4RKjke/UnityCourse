using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChecker : MonoBehaviour
{
    [SerializeField] private int CoinGoal = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ;
        var Player = collision.gameObject.GetComponent<Coin>();

        if (Player)
        {
            Player.DestoyEntity();
            CoinGoal -= 1;
        }
    }
}
