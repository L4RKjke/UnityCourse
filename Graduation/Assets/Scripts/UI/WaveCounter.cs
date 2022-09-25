using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Spawner _spawner;

    private void Update()
    {
        _scoreText.text = _spawner.NumberOfWave.ToString();
    }
}
