using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _alarmNotification;
    private float _currentSVolume = 0;
    private float maxStrength = 1;
    private float recoveryRate = 0.1f;
    private bool _isSomebodyIn = false;
    private GameObject _alarm;

    private void Start()
    {
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        _audioSource.volume = _currentSVolume;

        if(_isSomebodyIn)
            ActivateAlarm();
        else
            DeactivateAlarm();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm = Instantiate(_alarmNotification, new Vector2(0.791256f, 0.6429407f), Quaternion.identity);
        _isSomebodyIn = collision.TryGetComponent(out Character player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(_alarm);
        _isSomebodyIn = !collision.TryGetComponent(out Character player);
    }

    private void ActivateAlarm()
    {
        _currentSVolume = Mathf.MoveTowards(_currentSVolume, maxStrength, recoveryRate * Time.deltaTime);
    }

    private void DeactivateAlarm()
    {
        _currentSVolume = Mathf.MoveTowards(_currentSVolume, maxStrength, recoveryRate * Time.deltaTime * -1);
    }
}