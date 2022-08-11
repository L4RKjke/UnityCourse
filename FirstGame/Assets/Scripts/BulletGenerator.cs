using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bullet))]

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private float _bulletVelocity = 20f;
    [SerializeField] private GameObject _player;
    [SerializeField] private Bullet _bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var _newBullet = Instantiate(_bullet, transform.position, transform.rotation);

            if (_player.GetComponent<SpriteRenderer>().flipX == true)
            {
                _newBullet.CachedRigidbody2D.velocity = transform.right * _bulletVelocity * -1;
            }
            else
            {
                _newBullet.CachedRigidbody2D.velocity = transform.right * _bulletVelocity;
            }
        }
    }
}