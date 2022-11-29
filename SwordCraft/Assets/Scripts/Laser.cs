using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _laserFirePoint;
    [SerializeField] private Transform _slicerTransfrom;
    [SerializeField] private Slicer _slicer; 
    [SerializeField] private GreenLine _greenLine;
    [SerializeField] private GameObject _redRay;
    [SerializeField] private PlatformMover _model;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Transform _startLine;
    [SerializeField] private Transform _endLine;
    [SerializeField] private DirtController dirtController;
    [SerializeField] private PlatformMover platformMover;
    [SerializeField] private GameObject _laser;
    [SerializeField] private SwordTrigger _firstListener;
    [SerializeField] private SwordTrigger _secondListener;
    [SerializeField] private ScoreCounter _points;
    [SerializeField] private PlatformMover _swordMover;

    private int _sliceDirection;
    private bool _isTriggered = false;
    private RedLine _redLine;

    private readonly float _autoAimDistance = 0.05f;
    private readonly float _autoAimSpeed = 12;
    private readonly int _rightSliceYAngel = 180;
    private readonly int _leftSliceYAngel = 0;
    private readonly int _SliceZangel = 90;

    public Transform StartLine => _startLine;

    public Transform EndLine => _endLine;

    public UnityAction<Vector3> LaserHitted;
    private bool _isSwordHitted = false;

    private void Start()
    {
        _redLine = _redRay.GetComponent<RedLine>();
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, new Vector3(_slicerTransfrom.position.x, _slicerTransfrom.position.y, transform.position.z) );     
    }

    private void OnEnable()
    {
        _firstListener.SwordHittedAction += OnTriggered;
        _firstListener.MissSwordAction += OnMissSword;
        _secondListener.SwordHittedAction += OnTriggerRay;

    }

    private void OnDisable()
    {
        _firstListener.SwordHittedAction -= OnTriggered;
        _firstListener.MissSwordAction -= OnMissSword;
        _secondListener.SwordHittedAction -= OnTriggerRay;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Sword>(out _) || hit.collider.TryGetComponent<Rock>(out _) || hit.collider.TryGetComponent<SwordTriggerLine>(out _))
            {
                ActivateAimHelper();
                _isSwordHitted = true;
            }

            else if (_isSwordHitted == true)
            {
                SliceSword();
                _isSwordHitted = false;
            }
        }
    }

    private void ActivateAimHelper()
    {
        if (_isTriggered && Mathf.Abs(_startLine.position.x - transform.position.x) < _autoAimDistance)
        {
            _swordMover.transform.position = new Vector3((_swordMover.transform.position.x - (_startLine.position.x - transform.position.x) * Time.deltaTime * _autoAimSpeed),
                _swordMover.transform.position.y, _swordMover.transform.position.z);
            _model.DisableMove();
        }
    }

    private void SliceSword()
    {
        if (_swordMover.transform.position.x > 0)
        {
            _sliceDirection = 1;    
        }

        else
        {
            _sliceDirection = -1;  
        }

        if (_sliceDirection == 1)
        {
            dirtController.RemoveLeftRocks(0);
            _slicer.transform.rotation = Quaternion.Euler(0, _rightSliceYAngel, _SliceZangel);
        }
            
        else if (_sliceDirection == -1)
        {
            dirtController.RemoveRightRocks(0);
            _slicer.transform.rotation = Quaternion.Euler(0, _leftSliceYAngel, _SliceZangel);
        }
            
        LaserHitted?.Invoke(_slicerTransfrom.transform.position);
        _slicer.Slice();
    }

    private void OnTriggered(Collider collider)
    {
        _model.DisableMove();
        _greenLine.enabled = false;
    }

    private void OnMissSword()
    {
        if (Mathf.Abs(_startLine.position.x - transform.position.x) < 0.01f)
        {
            _points.AddPoint();
        }

        _model.SetDefaultMoveSpeed();
        _model.SetDefaultPosition();
        _model.EnableMove();
        _model.SetSpeed(3);
        _isTriggered = false;
    }

    private void OnTriggerRay(Collider collider)
    {
        _isTriggered = true;
        _swordMover.SetSlowMoveSpeed();
        _swordMover.EnableMove();
        _swordMover.SetSpeed(2.5f);
        _redRay.SetActive(true);
        _model.transform.rotation = Quaternion.Euler(0, 0, 0);
        _redLine.DrowLine();
        _greenLine.enabled = true;
        _greenLine.DrawGreenLine(_startLine.position, _endLine.position);
        _model.RotateSword(-1 * (180 / Mathf.PI) * Mathf.Atan((_endLine.position.x - _startLine.position.x) / (_endLine.position.z - _startLine.position.z)));
    }
}