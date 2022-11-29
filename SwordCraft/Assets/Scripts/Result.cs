using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private ScoreCounter _points;
    [SerializeField] private GameObject[] _stars;

    public int NumberOfStars { get; private set; }

    private readonly int _maxScore = 6;

    private void OnEnable()
    {
        CountNumberOfStars();
        DrowStars();
    }

    private void CountNumberOfStars()
    {
        var score = _maxScore;

        for (int i = 0; i < _stars.Length; i++)
        {
            if (_points.Score == score)
                NumberOfStars = _stars.Length - i;

            score -= 1;
        }
    }

    private void DrowStars()
    {
        for (int i = 0; i < NumberOfStars; i++)
        {
            _stars[i].SetActive(true);
        }
    }
}
