using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletPattern;

    [SerializeField] private int _damage;

    public Rigidbody2D Rigidbody2d { get; private set; }

    public int Damage => _damage;

    private void Start()
    {
        Rigidbody2d = _bulletPattern.GetComponent<Rigidbody2D>();
        Rigidbody2d.velocity = transform.right * _bulletSpeed;
    }
}