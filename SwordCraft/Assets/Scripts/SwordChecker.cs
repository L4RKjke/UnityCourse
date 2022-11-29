using UnityEngine;

public class SwordChecker : MonoBehaviour
{
    [SerializeField] private PlatformMover _model;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SwordTriggerLine>(out _))
        {
            _model.SetToMiddle();
            _model.DisableMove();
        }
    }
}