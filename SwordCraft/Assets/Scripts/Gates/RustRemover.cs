using UnityEngine;

public class RustRemover : Gate
{
    [SerializeField] private SwordMaterials _swordMaterial;
    [SerializeField] private SwordTrigger _listener;
    [SerializeField] private Sword _sword;

    private void OnEnable()
    {
        if (_listener != null)
        {
            _listener.MissSwordAction += SetNewMaterial;
            _listener.SwordHittedAction -= ActivateGate;
        }
    }

    private void OnDisable()
    {
        if (_listener != null)
        {
            _listener.MissSwordAction -= SetNewMaterial;
            _listener.SwordHittedAction += ActivateGate;
        }
    }

    private void SetNewMaterial()
    {
        _sword.SwordRenderer.sharedMaterial = _swordMaterial.Metal;
        _swordMaterial.DeleteRust();
        EnableMove();
    }
}

