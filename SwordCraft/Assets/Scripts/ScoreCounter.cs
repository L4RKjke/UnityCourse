using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;
    private readonly int _maxScore = 7;

    public int Score => _score;

    public void AddPoint()
    {
        if (_score < _maxScore)
        {
            _score++;
        }
    }
}
