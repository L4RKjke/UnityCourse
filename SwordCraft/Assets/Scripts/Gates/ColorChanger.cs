using UnityEngine;

public class ColorChanger : Gate
{
    [SerializeField] private Color _color;
    [SerializeField] private DirtController _dirt;
    [SerializeField] private Sword _sword;


    private void OnEnable()
    {
        Listener.MissSwordAction += SetNewColor;
        Listener.SwordHittedAction += ActivateGate;
    }

    private void OnDisable()
    {
        Listener.MissSwordAction -= SetNewColor;
        Listener.SwordHittedAction -= ActivateGate;
    }

    private void SetNewColor()
    {
        _sword.SwordMeshRenderer.material.color = _color;
        _dirt.PaintRocks(_color);
        EnableMove();
    }
}
