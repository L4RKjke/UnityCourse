using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private SwordTrigger _swordListener;
    [SerializeField] private GameObject _blueSpray;
    [SerializeField] private DirtController _dirt;
    [SerializeField] private Material _material;
    [SerializeField] private ScoreCounter _points;
    [SerializeField] private PlatformMover _platformMover;

    private GameObject _sword;

    private void OnEnable()
    {
        _swordListener.MissSwordAction += ActivateFinalSlicer;
        _swordListener.SwordHittedAction += ActivateParticles;
    }

    private void OnDisable()
    {
        _swordListener.MissSwordAction -= ActivateFinalSlicer;
        _swordListener.SwordHittedAction -= ActivateParticles;
    }

    private void ActivateFinalSlicer()
    {
        _platformMover.EnableMove();
        _platformMover.SetSpeed(_platformMover.FastSpeed);
        _sword.GetComponent<MeshRenderer>().material.color = _color;
        _dirt.PaintRocks(_color);
        _blueSpray.SetActive(false);
    }

    private void ActivateParticles(Collider sword)
    {
        _sword = sword.transform.parent.gameObject;
        _platformMover.DisableMove();
        _platformMover.SetSpeed(_platformMover.SlowSpeed);
        _blueSpray.SetActive(true);     
    }
}