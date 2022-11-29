using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPointTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _finalUI;
    [SerializeField] private DirtController _dirtController;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Material _targetMaterial;
    [SerializeField] private Color _targetColor;
    [SerializeField] private GameObject _pouseMenu;
    [SerializeField] private Result _result;
    [SerializeField] private CoinWallet _wallet;
    [SerializeField] private AddYandex _yandexAd;

    private int _currentLevelIndex;

    private readonly int _maxHandleIndex = 5;

    private void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Sword>(out Sword sword))
        {
            _yandexAd.ShowAd();

            if (sword.GetComponent<Renderer>().material.color == _targetColor && sword.GetComponentInParent<SwordMaterials>().CurrentMaterial == _targetMaterial)
            {
                AddPoint();
            }

            if (_dirtController.IsDirtCleaned == true)
                AddPoint();

            _pouseMenu.SetActive(false);
            ActivateUI();
            SaveLevelData();
        }
    }

    private void ActivateUI()
    {
        for (int i = 0; i < _finalUI.Length - 1; i++)
        {
            _finalUI[i].SetActive(true);
        }
    }

    private void SaveLevelData()
    {
        if (_result.NumberOfStars == 3 && PlayerPrefs.GetInt("MaxHandle") <= _maxHandleIndex)
        {
            _finalUI[_finalUI.Length - 1].SetActive(true);
            PlayerPrefs.SetInt("MaxHandle", PlayerPrefs.GetInt("MaxHandle") + 1);
        }

        if (PlayerPrefs.GetInt("MaxLevel") < _currentLevelIndex)
            PlayerPrefs.SetInt("MaxLevel", _currentLevelIndex);

        if (_result.NumberOfStars > PlayerPrefs.GetInt(_currentLevelIndex.ToString()))
            PlayerPrefs.SetInt(_currentLevelIndex.ToString(), _result.NumberOfStars);

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + _wallet.Coins);
        Leaderboard.SetScore("LeaderboardCoins", PlayerPrefs.GetInt("Coins"));
    }

    private void AddPoint()
    {
        _scoreCounter.AddPoint();
    }
}
