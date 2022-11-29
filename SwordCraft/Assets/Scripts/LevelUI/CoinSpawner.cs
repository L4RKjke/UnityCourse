using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _coinPoints;

    private void Start()
    {
        for (int i = 0; i < _coinPoints.Length; i++)
        {
            Instantiate(_coinPrefab, _coinPoints[i].position, Quaternion.identity);
        }
    }
}
