using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _scanningArea;

    private EnemyDetector _enemyDetector;
    private IEnumerator _corutine;
    private float _recoveryRate = 0.1f;
    private float _maxStrength = 1;

    private void Start()
    {
        _enemyDetector = _scanningArea.GetComponent<EnemyDetector>();
        _audioSource.volume = 0f;
        _enemyDetector.EnemyInZone += StartNewVolumeCoroutin;
    }

    private IEnumerator SetVolume(bool isSomebodyIn)
    {
        while (true)
        {
            if (isSomebodyIn)
            {
                yield return _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxStrength, _recoveryRate * Time.deltaTime);
            }

            else
            {
                yield return _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxStrength, -_recoveryRate * Time.deltaTime);
            }           
        }
    }

    private void StartNewVolumeCoroutin(bool isSomebodyIn)
    {
        if (_corutine is not null)
            StopCoroutine(_corutine);

        _corutine = SetVolume(isSomebodyIn);
        StartCoroutine(_corutine);
    }
}