using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChecker : MonoBehaviour
{
    [SerializeField] private int CoinGoal = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ;
        var Player = collision.gameObject.GetComponent<Entity>();

        if (Player && collision.gameObject.name == "Coin")
        {
            Player.DestoyEntity();
            CoinGoal -= 1;
        }

        if (CoinGoal == 0)
            Debug.Log("WIN");
    }
}
