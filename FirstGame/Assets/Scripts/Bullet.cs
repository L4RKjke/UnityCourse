using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    public Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Entity = collision.gameObject.GetComponent<Entity>();

        if (Entity)
        {
            Entity.DestoyEntity();
        }
        Destroy(gameObject);
    }
}


