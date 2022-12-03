using UnityEngine;

public class ColorChanger : Gate
{
    [SerializeField] private Color _color;
    [SerializeField] private SwordTrigger _swordListener;
    [SerializeField] private DirtController _dirt;
    [SerializeField] private Sword _sword;


    private void OnEnable()
    {
        _swordListener.MissSwordAction += ActivateFinalSlicer;
        _swordListener.SwordHittedAction += ActivateGate;
    }

    private void OnDisable()
    {
        _swordListener.MissSwordAction -= ActivateFinalSlicer;
        _swordListener.SwordHittedAction -= ActivateGate;
    }

    private void ActivateFinalSlicer()
    {
        _sword.SwordMeshRenderer.material.color = _color;
        _dirt.PaintRocks(_color);
        EnableMove();
    }
}
