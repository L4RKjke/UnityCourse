using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private EnemyRed _enemy;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _enemy.PlayerChangeHealth += ChangeHealthbar;
    }

    private void ChangeHealthbar(float value)
    {
        _slider.value = _enemy.Health;
    }
}