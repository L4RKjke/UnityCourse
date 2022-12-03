using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Sword : MonoBehaviour
{
    [SerializeField] private SwordMaterials _swordMaterials;
    [SerializeField] private GameObject _model;

    public Renderer SwordRenderer => GetComponent<Renderer>();

    public MeshRenderer SwordMeshRenderer => GetComponent<MeshRenderer>();

    private void Start()
    {
        if (gameObject != null && _swordMaterials != null)
            GetComponent<Renderer>().sharedMaterial = _swordMaterials.RustyMetal;
    }

    public void OnCoinTrigger()
    {
        transform.GetComponentInParent<CoinWallet>().AddCoin();
    }
}
