using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _player.PlayerChangeHealth += ChangeHealthbar;
    }

    private void ChangeHealthbar(float value)
    {
        if (_player.Health == 0)
            gameObject.SetActive(false);

        _slider.value = _player.Health;
    }
}

