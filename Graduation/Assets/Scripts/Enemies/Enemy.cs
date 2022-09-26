using UnityEngine;
using UnityEngine.Events;

abstract public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _enemy;

    public delegate void PlayerHealthEvent(float argument);

    public event PlayerHealthEvent PlayerChangeHealth;

    public UnityAction<Enemy> EnemyDie;

    public int Health => _health;

    abstract public void StartShooting();

    abstract public void StopShooting();

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            Debug.Log("damage should be possitive number!");

        if (Health > 0)
        {
            _health -= damage;
            PlayerChangeHealth?.Invoke(_health);
        }

        if (Health == 0)
        {
            EnemyDie.Invoke(this);
            Destroy(_enemy);
        }
    }
}
