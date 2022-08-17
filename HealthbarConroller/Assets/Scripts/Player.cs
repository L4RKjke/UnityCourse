using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100;

    public delegate void PlayerHealthEvent(float argument);

    public event PlayerHealthEvent PlayerChangeHealth;

    private readonly float _minHealth = 0;

    public float MaxHealth { get; private set; } = 100;

    public void TakeDamage(float damageValue)
    {
        if (_health > _minHealth && damageValue >= 0)
        {
            _health -= damageValue;
            PlayerChangeHealth?.Invoke(_health);
        }
    }

    public void Heal(float healValue)
    {
        if (_health < MaxHealth && _health != _minHealth && healValue >= 0)
        {
            _health += healValue;
            PlayerChangeHealth?.Invoke(_health);
        }
    }
}
