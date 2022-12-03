using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject _blueSpray;
    [SerializeField] private PlatformMover _platformMover;

    protected void ActivateGate(Collider sword)
    {
        DisableMove();
        _platformMover.DisableMove();
        _platformMover.SetSpeed(_platformMover.SlowSpeed);
        _blueSpray.SetActive(true);
    }

    protected void EnableMove()
    {
        _platformMover.EnableMove();
        _platformMover.SetSpeed(_platformMover.FastSpeed);
        _blueSpray.SetActive(false);
    }

    protected void DisableMove()
    {
        _platformMover.DisableMove();
        _platformMover.SetSpeed(_platformMover.SlowSpeed);
    }
}
