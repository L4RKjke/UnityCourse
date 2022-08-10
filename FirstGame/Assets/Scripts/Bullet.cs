using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Entity = collision.gameObject.GetComponent<Entity>();

        if (Entity && collision.gameObject.name != "Coin")
        {
            Entity.DestoyEntity();
        }
        Destroy(gameObject);
    }
}
