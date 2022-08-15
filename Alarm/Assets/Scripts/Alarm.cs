using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject ScanningArea;

    private EnemyDetector _enemyDetector;
    private float _recoveryRate = 0.1f;
    private float _minStrength = 0;
    private float _maxStrength = 1;

    private void Start()
    {
        _enemyDetector = ScanningArea.GetComponent<EnemyDetector>();
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        if (_enemyDetector.IsSomebodyIn && _audioSource.volume == _minStrength || !_enemyDetector.IsSomebodyIn && _audioSource.volume == _maxStrength)
            StartCoroutine(SetVolume());
        else
            StopCoroutine(SetVolume());
    }

    private IEnumerator SetVolume()
    {
        while (true)
        {
            if (_audioSource.volume == _maxStrength && _enemyDetector.IsSomebodyIn || _audioSource.volume == _minStrength && !_enemyDetector.IsSomebodyIn)
            
                break;

            if (_enemyDetector.IsSomebodyIn)
            
                yield return _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxStrength, _recoveryRate * Time.deltaTime);
               
            else
            
                yield return _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxStrength, -_recoveryRate * Time.deltaTime);       
        }
    }
}
