using System;
using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private EnemyDetector _enemyDetector;

    private Coroutine _corutine;
    private float _recoveryRate = 0.1f;
    private float _maxStrength = 1;
    private float _minStrength = 0;

    private void Start()
    {
        _audioSource.volume = 0f;
    }

    private IEnumerator SetVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            yield return _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _recoveryRate * Time.deltaTime);
        }
    }

    private void StartNewCourutine(bool isSomebodyIn) 
    {
        if (_corutine is not null)
            StopCoroutine(_corutine);

        if (isSomebodyIn)
        {
            _corutine = StartCoroutine(SetVolume(_maxStrength));
        }    

        else
        {
            _corutine = StartCoroutine(SetVolume(_minStrength));
        }
    }

    private void OnDisable()
    {
        _enemyDetector.EnemyInZone -= StartNewCourutine;
    }

    private void OnEnable()
    {
        _enemyDetector.EnemyInZone += StartNewCourutine;
    }
}
