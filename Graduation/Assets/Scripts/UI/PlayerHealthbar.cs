using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : Healthbar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.PlayerChangeHealth += ChangeHealthbar;
    }

    private void OnDisable()
    {
        _player.PlayerChangeHealth -= ChangeHealthbar;
    }

    override public void ChangeHealthbar(float value)
    {
        if (_player.Health == 0)
            gameObject.SetActive(false);

        Slider.value = _player.Health;
    }
}