using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class HandleAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Transform _target;

    public UnityAction _onTarget;

    private void OnEnable()
    {     
        _onTarget += SetParent;
        transform.DORotate(new Vector3(0, 180, 0), 1f);
        transform.DOJump(new Vector3(_target.position.x, _target.position.y, _target.position.z), 1, 1, 1f, false).OnComplete(() => _onTarget?.Invoke()).SetAutoKill(true);    
    }

    private void OnDisable()
    {
        _onTarget -= SetParent;
    }

    private void SetParent()
    {
        gameObject.transform.SetParent(_model.transform, true);
        enabled = false;
    }
}