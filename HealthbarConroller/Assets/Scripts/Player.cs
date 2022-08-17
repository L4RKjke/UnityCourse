using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100;

    public delegate void PlayerAtackedEvent(float argument);

    public delegate void PlayerHealedEvent(float argument);

    public event PlayerAtackedEvent PlayerAtacked;

    public event PlayerHealedEvent PlayerHealed;

    private readonly float _damage = 10;
    private readonly float _heal = 10;
    private readonly float _maxHealth = 100;
    private readonly float _minHealth = 0;

    public void TakeDamage()
    {
        if (_health > _minHealth && _health > 0)
        {
            _health -= _damage;
            PlayerAtacked?.Invoke(_health);
        }
    }

    public void Heal()
    {
        if (_health < _maxHealth && _health > 0)
        {
            _health += _heal;
            PlayerHealed?.Invoke(_health);
        }
    }
}
