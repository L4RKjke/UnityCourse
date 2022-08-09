using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private float _spawnRate = 2;
    private float[] _enemyPointsX = new float[5];
    private float[] _enemyPointsY = new float[5];
    private GameObject _cloneEnemy;

    void Start()
    {
        _enemyPointsX[0] = -7.445422f;
        _enemyPointsX[1] = -2.44f;
        _enemyPointsX[2] = 1.6f;
        _enemyPointsX[3] = 4.65f;
        _enemyPointsX[4] = 7.62f;
        _enemyPointsY[0] = -0.9748187f;
        _enemyPointsY[1] = -0.06f;
        _enemyPointsY[2] = 0;
        _enemyPointsY[3] = -0.94f;
        _enemyPointsY[4] = -1.98f;
    }
    
    void Update()
    {
        _spawnRate -= Time.deltaTime;
        
        if (_spawnRate <= 0)
        {
            int RandonValue = Random.Range(0, 5);
            
            if (_cloneEnemy != null)
            {
                Destroy(_cloneEnemy.gameObject);
            }

            _cloneEnemy = Instantiate(_enemy, new Vector2(_enemyPointsX[RandonValue], _enemyPointsY[RandonValue]), Quaternion.identity);       
            _spawnRate = 2;
        }
    }
}
