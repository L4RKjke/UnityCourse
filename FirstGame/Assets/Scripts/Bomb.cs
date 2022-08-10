using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Player = collision.gameObject.GetComponent<Entity>();

        if (Player && collision.gameObject.name == "Player")
        {
            Player.DestoyEntity();
            Debug.Log("GameOver!");
            Destroy(gameObject);
        }
    }
}
