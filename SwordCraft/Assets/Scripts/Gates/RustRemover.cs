using UnityEngine;

public class RustRemover : MonoBehaviour
{
    [SerializeField] private SwordMaterials _swordMaterial;
    [SerializeField] private GameObject _blueSpray;
    [SerializeField] private SwordTrigger _listener;
    [SerializeField] private ScoreCounter _points;
    [SerializeField] private PlatformMover _platformMover;

    private Renderer _render;

    private void OnEnable()
    {
        if (_listener != null)
        {
            _listener.SwordHittedAction += ActivateSpray;
            _listener.MissSwordAction += SetNewMaterial;
        }
    }

    private void OnDisable()
    {
        if (_listener != null)
        {
            _listener.SwordHittedAction -= ActivateSpray;
            _listener.MissSwordAction -= SetNewMaterial;
        }
    }

    private void ActivateSpray(Collider sword)
    {
        _platformMover.DisableMove();
        _platformMover.SetSpeed(_platformMover.SlowSpeed);
        _blueSpray.SetActive(true);
        _render = sword.transform.parent.gameObject.GetComponent<Renderer>();
    }

    private void SetNewMaterial()
    {
        _platformMover.EnableMove();
        _platformMover.SetSpeed(_platformMover.FastSpeed);

        if (_render != null)
        {
            _render.sharedMaterial = _swordMaterial.Metal;
            _swordMaterial.DeleteRust();
        }

        _blueSpray.SetActive(false);
    }
}
