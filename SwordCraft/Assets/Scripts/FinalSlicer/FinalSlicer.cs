using UnityEngine;

public class FinalSlicer : MonoBehaviour
{
    [SerializeField] private SwordTrigger _swordListener;
    [SerializeField] private GameObject _endSlicer;
    [SerializeField] private GameObject _particles;
    [SerializeField] private PlatformMover _model;
    [SerializeField] private DirtController _generator;

    private void OnEnable()
    {
        _swordListener.MissSwordAction += ActivateFinalSlicer;
        _swordListener.SwordHittedAction += ActivateParticles;
    }

    private void OnDisable()
    {
        _swordListener.MissSwordAction -= ActivateFinalSlicer;
        _swordListener.SwordHittedAction -= ActivateParticles;
    }

    private void ActivateFinalSlicer()
    {
        _generator.RemoveAllRocks();
        _particles.SetActive(false);
        _endSlicer.SetActive(true);
        _model.SetSpeed(2f);
    }

    private void ActivateParticles()
    {
        _model.SetSpeed(0.6f);
        _particles.SetActive(true);
    }
}
