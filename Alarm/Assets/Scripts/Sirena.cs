using UnityEngine;

public class Sirena : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private float _currentSVolume = 0;
    private float _maxStrength = 1;
    private float _recoveryRate = 0.1f;

    private void Start()
    {
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        _audioSource.volume = _currentSVolume;
    }

        public void ActivateAlarm()
    {
        _currentSVolume = Mathf.MoveTowards(_currentSVolume, _maxStrength, _recoveryRate * Time.deltaTime);
    }

    public void DeactivateAlarm()
    {
        _currentSVolume = Mathf.MoveTowards(_currentSVolume, _maxStrength, -_recoveryRate * Time.deltaTime);
    }
}
