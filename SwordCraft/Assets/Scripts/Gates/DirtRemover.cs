using UnityEngine;

public class DirtRemover : Gate
{
    [SerializeField] private DirtController _generator;
    [SerializeField] private SwordTrigger _listener;

    private void Start()
    {
        if (_listener != null)
        {
            _listener.MissSwordAction += CleanDirt;
            _listener.SwordHittedAction += ActivateGate;
        }
    }

    private void OnDisable()
    {
        if (_listener != null)
        {
            _listener.MissSwordAction -= CleanDirt;
            _listener.SwordHittedAction -= ActivateGate;
        }
    }

    private void CleanDirt()
    {
        _generator.CleanSword();
        EnableMove();
    }
}
