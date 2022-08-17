using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private Coroutine _corutine;
    private readonly float _healthRate = 0.1f;

    private void OnEnable()
    {
        _player.PlayerAtacked += ChangeHealthbar;
        _player.PlayerHealed += ChangeHealthbar;
    }

    private void OnDisable()
    {
        _player.PlayerAtacked -= ChangeHealthbar;
        _player.PlayerHealed -= ChangeHealthbar;
    }

    private void ChangeHealthbar(float value)
    {
        if (_corutine is not null)
            StopCoroutine(_corutine);

        _corutine = StartCoroutine(SetHealth(value/100));
    }

    private IEnumerator SetHealth(float target)
    {
        while (_slider.value != target)
        {
            yield return _slider.value = Mathf.MoveTowards(_slider.value, target, _healthRate * Time.deltaTime);
        }
    }
}
