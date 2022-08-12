using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed;

    public Rigidbody2D Rigidbody2d { get; private set; }

    private void Start()
    {
        Rigidbody2d = _bullet.GetComponent<Rigidbody2D>();
        Rigidbody2d.velocity = transform.right * _bulletSpeed; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Entity entity))
        {
            entity.DestoyEntity();
        }
        Destroy(gameObject);
    }
}