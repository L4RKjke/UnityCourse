using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform _slicerTransfrom;
    [SerializeField] private Slicer _slicer; 
    [SerializeField] private PlatformMover _model;
    [SerializeField] private Transform _startLine;
    [SerializeField] private DirtController dirtController;
    [SerializeField] private PlatformMover _swordMover;
    [SerializeField] private LineRenderer _lineRenderer;

    private int _sliceDirection;

    private readonly float _autoAimDistance = 0.03f;
    private readonly float _autoAimSpeed = 12;
    private readonly int _rightSliceYAngel = 180;
    private readonly int _leftSliceYAngel = 0;
    private readonly int _SliceZangel = 90;

    public UnityAction<Vector3> LaserHitted;
    private bool _isSwordHitted = false;

    private void Start()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, new Vector3(_slicerTransfrom.position.x, _slicerTransfrom.position.y, transform.position.z));
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Sword>(out _) || hit.collider.TryGetComponent<Rock>(out _) || hit.collider.TryGetComponent<SwordTriggerLine>(out _))
            {
                MoveToCentre();
                _isSwordHitted = true;
            }

            else if (_isSwordHitted == true)
            {
                SliceSword();
                _isSwordHitted = false;
            }
        }
    }

    private void MoveToCentre()
    {
        if (Mathf.Abs(_startLine.position.x - transform.position.x) < _autoAimDistance)
        {
            _swordMover.transform.position = new Vector3((_swordMover.transform.position.x - (_startLine.position.x - transform.position.x) * Time.deltaTime * _autoAimSpeed),
                _swordMover.transform.position.y, _swordMover.transform.position.z);
            _model.DisableMove();
        }
    }

    private void SliceSword()
    {
        if (_swordMover.transform.position.x > 0)
        {
            _sliceDirection = 1;    
        }

        else
        {
            _sliceDirection = -1;  
        }

        if (_sliceDirection == 1)
        {
            dirtController.RemoveLeftRocks(0);
            _slicer.transform.rotation = Quaternion.Euler(0, _rightSliceYAngel, _SliceZangel);
        }
            
        else if (_sliceDirection == -1)
        {
            dirtController.RemoveRightRocks(0);
            _slicer.transform.rotation = Quaternion.Euler(0, _leftSliceYAngel, _SliceZangel);
        }
            
        LaserHitted?.Invoke(_slicerTransfrom.transform.position);
        _slicer.Slice();
    }
}