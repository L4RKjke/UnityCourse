using UnityEngine;

public class SwordMaterials : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private Material _currentMaterial;

    public Material Metal => _materials[1];

    public Material RustyMetal => _materials[0];

    public Material CurrentMaterial => _currentMaterial;

    public void DeleteRust() 
    {
        _currentMaterial = _materials[1];
    }
}
