using UnityEngine;

public class RustRemover : Gate
{
    [SerializeField] private DirtController _generator;
    [SerializeField] private SwordMaterials _swordMaterial;

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
        Sword.SwordRenderer.sharedMaterial = _swordMaterial.Metal;
        _swordMaterial.DeleteRust();
        EnableMove();
    }
}