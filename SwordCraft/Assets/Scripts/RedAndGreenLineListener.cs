using UnityEngine;

public class RedAndGreenLineListener : MonoBehaviour
{
    [SerializeField] private SwordTrigger _swordListener;
    [SerializeField] private PlatformMover _platformMover;
    [SerializeField] private Laser _laser;
    [SerializeField] private GameObject _laserLogic;

    private void OnEnable()
    {
        _swordListener.MissSwordAction += SwitchOffLaser;
    }

    private void OnDisable()
    {
        _swordListener.MissSwordAction -= SwitchOffLaser;
    }

    private void SwitchOffLaser()
    {
        _platformMover.SetDefaultPosition();
        _platformMover.EnableMove();
        _platformMover.SetSpeed(3);
    }
}
