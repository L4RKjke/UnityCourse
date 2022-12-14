using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnRate = 2.0f;
    [SerializeField] private Transform _enemySpawner;
    private GameObject _cloneEnemy;   
    private Transform[] _points = new Transform[5];

    private void Start()
    {      
        for (int i = 0; i < _enemySpawner.childCount; i++) 
        {
            _points[i] = _enemySpawner.GetChild(i);
        }
        StartCoroutine(SpawnEnemy());
    }
    
    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            var RandomPoint = _points[Random.Range(0, 5)].position;

            if (_cloneEnemy != null)
            {
                Destroy(_cloneEnemy.gameObject);
            }

            _cloneEnemy = Instantiate(_enemy, RandomPoint, Quaternion.identity);

            yield return new WaitForSeconds(_spawnRate);
        }
    }
}