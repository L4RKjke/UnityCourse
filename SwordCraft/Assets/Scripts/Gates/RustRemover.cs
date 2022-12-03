using UnityEngine;

public class RustRemover : Gate
{
    [SerializeField] private DirtController _generator;
    [SerializeField] private SwordMaterials _swordMaterial;
    [SerializeField] private Sword _sword;

    private void Start()
    {
        if (Listener != null)
        {
            Listener.MissSwordAction += SetNewMaterial;
            Listener.SwordHittedAction += ActivateGate;
        }
    }

    private void OnDisable()
    {
        if (Listener != null)
        {
            Listener.MissSwordAction -= SetNewMaterial;
            Listener.SwordHittedAction -= ActivateGate;
        }
    }

    private void SetNewMaterial()
    {
        _sword.SwordRenderer.sharedMaterial = _swordMaterial.Metal;
        _swordMaterial.DeleteRust();
        EnableMove();
    }
}