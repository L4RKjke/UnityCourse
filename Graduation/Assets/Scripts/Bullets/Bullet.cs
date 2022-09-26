using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody2D _bulletRigidbody2D;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    private void Start()
    {
        _bulletRigidbody2D.velocity = transform.right * _bulletSpeed;
    }
}