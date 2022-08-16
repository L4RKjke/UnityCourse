using System.Collections;
using UnityEngine;
using System;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private EnemyDetector _enemyDetector;

    private Coroutine _corutine;
    private float _recoveryRate = 0.1f;
    private float _maxStrength = 1;

    private void Start()
    {
        _audioSource.volume = 0f;
        _enemyDetector.EnemyInZone += (isSomebodyIn)  => {_corutine = StartCoroutine(SetVolume(_maxStrength * Convert.ToInt32(isSomebodyIn)));};
    }

    private IEnumerator SetVolume(float target)
    {
        if (_corutine is not null)
            StopCoroutine(_corutine);

        while (_audioSource.volume != target)
        {
            yield return _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _recoveryRate * Time.deltaTime);
        }
    }
}