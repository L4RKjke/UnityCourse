using UnityEngine;

public class AimHelper : MonoBehaviour
{
    [SerializeField] private GreenLine _greenLine;
    [SerializeField] private GameObject _redRay;
    [SerializeField] private PlatformMover _model;
    [SerializeField] private Transform _startLine;
    [SerializeField] private Transform _endLine;
    [SerializeField] private PlatformMover platformMover;
    [SerializeField] private SwordTrigger _firstListener;
    [SerializeField] private SwordTrigger _secondListener;
    [SerializeField] private ScoreCounter _points;
    [SerializeField] private PlatformMover _swordMover;

    private RedLine _redLine;

    public Transform StartLine => _startLine;

    public Transform EndLine => _endLine;

    private void OnEnable()
    {
        _redLine = _redRay.GetComponent<RedLine>();
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
    }

    private void OnTriggerRay(Collider collider)
    {
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
