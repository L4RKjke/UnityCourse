using UnityEngine;

public class DirtRemover : MonoBehaviour
{
    [SerializeField] private DirtController _generator;
    [SerializeField] private GameObject _blueSpray;
    [SerializeField] private SwordTrigger _listener;
    [SerializeField] private ScoreCounter _points;
    [SerializeField] private PlatformMover _platformMover;

    private void Start()
    {
        if (_listener != null)
        {
            _listener.MissSwordAction += CleanDirt;
            _listener.SwordHittedAction += ActivateSpray;
        }
    }

    private void OnDisable()
    {
        if (_listener != null)
        {
            _listener.MissSwordAction -= CleanDirt;
            _listener.SwordHittedAction -= ActivateSpray;
        }
    }

    private void CleanDirt()
    {
        _platformMover.EnableMove();
        _platformMover.SetSpeed(_platformMover.FastSpeed);
        _blueSpray.SetActive(false);
        _generator.CleanSword();
    }

    private void ActivateSpray(Collider sword)
    {
        _platformMover.DisableMove();
        _platformMover.SetSpeed(_platformMover.SlowSpeed);
        _blueSpray.SetActive(true);
    }
}
