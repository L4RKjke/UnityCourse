using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private float _bulletVelocity = 20f;
    [SerializeField] private GameObject _player;
    [SerializeField] private Bullet _bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var _newBullet = Instantiate(_bullet, transform.position, transform.rotation);

            if (_player.GetComponent<SpriteRenderer>().flipX == true)
            {
                _newBullet.GetComponent<Bullet>().Rigidbody2D.velocity = transform.right * -_bulletVelocity;
            }
            else
            {
                _newBullet.GetComponent<Bullet>().Rigidbody2D.velocity = transform.right * _bulletVelocity;
            }
        }
    }
}