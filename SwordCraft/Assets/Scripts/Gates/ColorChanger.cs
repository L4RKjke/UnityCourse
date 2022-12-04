using UnityEngine;

public class ColorChanger : Gate
{
    [SerializeField] private Color _color;
    [SerializeField] private DirtController _dirt;


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
        Sword.SwordMeshRenderer.material.color = _color;
        _dirt.PaintRocks(_color);
        EnableMove();
    }
}
