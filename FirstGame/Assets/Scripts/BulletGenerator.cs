using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletVelocity = 20f;
    [SerializeField] private GameObject _player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(_bullet, transform.position, transform.rotation);

            if (_player.GetComponent<SpriteRenderer>().flipX == true)
            {
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * -_bulletVelocity;
            }
            else
            {
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * _bulletVelocity;
            }
            
        }
    }
}
