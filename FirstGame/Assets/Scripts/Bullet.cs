using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    private Rigidbody2D _rigidbody2D = null;

    public Rigidbody2D CachedRigidbody2D
    {
        get
        {
            if (!_rigidbody2D)
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }
            return _rigidbody2D;
        }
    }

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


