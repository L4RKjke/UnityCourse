using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _template;
    [SerializeField] private int _startEneiesInWave = 7;

    private int _currentNumberOfEnemies;
    private int _enemiesInNewWave = 5;
    private int _numberOfWave = 1;

    private readonly int _minX = 7;
    private readonly int _minY = 5;
    private readonly int _maxX = 20;
    private readonly int _maxY = 18;
    private readonly string _waitForSeconds = "WaitForSeconds";
    private readonly int _enemySpriteIndex = 0;

    public int NumberOfWave => _numberOfWave;

    private void Start()
    {
        _enemiesInNewWave = _startEneiesInWave;
        SpawnNewEnemies();
    }

    private void OnDisable()
    {
        StopCoroutine(_waitForSeconds);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.EnemyDie -= OnEnemyDying;
        _currentNumberOfEnemies--;

        if (_currentNumberOfEnemies == 0)
        {
            _numberOfWave++;
            _enemiesInNewWave++;
            SpawnNewEnemies();
        }
    }

    private void SpawnNewEnemies()
    {
        StartCoroutine(_waitForSeconds);
    }

    private Vector2 GetRandomVector(int minX, int minY, int maxX, int maxY)
    {
        int[] directions = new int[2] { -1, 1 };

        var RandowmSpawnRadiousX = Random.Range(minX, maxX);
        var RandowmSpawnRadiousY = Random.Range(minY, maxY);
        var RandomDirectionX = directions[Random.Range(0, 2)];
        var RandomDirectionY = directions[Random.Range(0, 2)];

        return new Vector2((RandomDirectionX * RandowmSpawnRadiousX) + _character.transform.position.x,
            (RandomDirectionY * RandowmSpawnRadiousY) + _character.transform.position.y);
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_template, GetRandomVector(_minX, _minY, _maxX, _maxY),
            Quaternion.identity).transform.GetChild(_enemySpriteIndex).GetComponent<EnemyRed>();

        enemy.Init(_player);
        enemy.EnemyDie += OnEnemyDying;
    }

    private IEnumerator WaitForSeconds()
    {
        while(true)
        {
            SpawnEnemy();
            _currentNumberOfEnemies++;

            if (_currentNumberOfEnemies == _enemiesInNewWave)
                StopCoroutine(_waitForSeconds);

            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
