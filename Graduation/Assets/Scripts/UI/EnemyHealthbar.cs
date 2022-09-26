using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : Healthbar
{
    [SerializeField] private EnemyRed _enemy;

    private void OnEnable()
    {
        _enemy.PlayerChangeHealth += ChangeHealthbar;
    }

    private void OnDisable()
    {
        _enemy.PlayerChangeHealth -= ChangeHealthbar;
    }

    override public void ChangeHealthbar(float value)
    {
        Slider.value = _enemy.Health;
    }
}