using UnityEngine;

public class DirtController: MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private GameObject _model;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Renderer _render;
    [SerializeField] private GameObject _dirtPoint;

    private int _randomNumbersOfStones;
    private GameObject[] _rocks;
    private Vector3 _size;

    private readonly int _minNumbersOfStones = 20;
    private readonly int _maxNumbersOfStones = 30;
    private readonly float _spread = 0.03f;
    private readonly float _minScale = 0.08f;
    private readonly float _maxScale = 0.11f;
    private readonly int _maxAngel1 = 10;
    private readonly int _maxAngel2 = 179;

    public bool IsDirtCleaned { get; private set; } = false;

    private void Start()
    {
        GenerateDirt();
    }

    private void GenerateDirt()
    {
        _size = _renderer.bounds.size;
        _randomNumbersOfStones = Random.Range(_minNumbersOfStones, _maxNumbersOfStones);
        int randomTemplate = Random.Range(0, _templates.Length);
        _render = GetComponent<Renderer>();
        _render.enabled = true;
        _rocks = new GameObject[_randomNumbersOfStones];

        for (int i = 0; i < _randomNumbersOfStones; i++)
        {
            var rockPosition = new Vector3(Random.Range(-_size.x / 2 + _spread, _size.x / 2 - _spread) + transform.position.x, _dirtPoint.transform.position.y + Random.Range(-_spread, -_spread + 0.01f), Random.Range(-_size.z / 2 + _spread, _size.z / 2 - _spread) + transform.position.z);

            _rocks[i] = Instantiate(_templates[randomTemplate], rockPosition,
                    Quaternion.Euler(Random.Range(0, _maxAngel1), Random.Range(0, _maxAngel2), Random.Range(0, _maxAngel1))) as GameObject;

            _rocks[i].transform.localScale = new Vector3(Random.Range(_minScale, _maxScale), Random.Range(_minScale, _maxScale), Random.Range(_minScale, _minScale));
            _rocks[i].transform.SetParent(_model.transform, true);
            _rocks[i].layer = 9;

            randomTemplate = Random.Range(0, _templates.Length);
        }
    }

    public void RemoveRightRocks(float xPosition)
    {
        for (int i = 0; i < _randomNumbersOfStones; i++)
        {
            if (_rocks[i].transform.position.x > xPosition)
                _rocks[i].SetActive(false);
        }
    }


    public void RemoveLeftRocks(float xPosition)
    {
        for (int i = 0; i < _randomNumbersOfStones; i++)
        {
            if (_rocks[i].transform.position.x < xPosition)
                _rocks[i].SetActive(false);
        }
    }

    public void RemoveAllRocks()
    {
        for (int i = 0; i < _randomNumbersOfStones; i++)
        {
            _rocks[i].SetActive(false);
        }
    }

    public void CleanSword()
    {
        IsDirtCleaned = true;
        RemoveAllRocks();
    }

    public void PaintRocks(Color color)
    {
        for (int i = 0; i < _randomNumbersOfStones; i++)
        {
            if(_rocks[i].TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
                renderer.material.color = color;
        }
    }
}
