using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Bullet _bullet;
    private SpriteRenderer _playerSpriteRenderer;
    private int _bulletLeftDirection = 0;
    private int _bulletRightDirection = 180;

    private void Start()
    {
        _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_playerSpriteRenderer.flipX)
            {
                CreateBullet(_bulletRightDirection);
            }
            else
            {
                CreateBullet(_bulletLeftDirection);
            }
        }
    }

    private void CreateBullet(float angel)
    {
        Instantiate(_bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angel)));
    }
}