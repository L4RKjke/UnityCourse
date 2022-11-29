using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] private PlatformMover _platformMover;
    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _finalSwordModel;
    [SerializeField] private HandleAnimator _handleAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Sword>(out _) || other.TryGetComponent<Rock>(out _))
        {
            _platformMover.enabled = false;
            _model.transform.SetParent(_finalSwordModel.transform, true);
            _handleAnimator.enabled = true;
        }
    }
}
