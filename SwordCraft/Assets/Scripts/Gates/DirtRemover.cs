using UnityEngine;

public class DirtRemover : Gate
{
    [SerializeField] private DirtController _generator;

    private void Start()
    {
        if (Listener != null)
        {
            Listener.MissSwordAction += CleanDirt;
            Listener.SwordHittedAction += ActivateGate;
        }
    }

    private void OnDisable()
    {
        if (Listener != null)
        {
            Listener.MissSwordAction -= CleanDirt;
            Listener.SwordHittedAction -= ActivateGate;
        }
    }

    private void CleanDirt()
    {
        _generator.CleanSword();
        EnableMove();
    }
}
