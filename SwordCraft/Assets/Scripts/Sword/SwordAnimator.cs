using DG.Tweening;
using UnityEngine;

public class SwordAnimator : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private HandleAnimator _handleAnimator;

    private void OnEnable()
    {
        _handleAnimator.JumpCompleted += Jump;
    }

    private void OnDisable()
    {
        _handleAnimator.JumpCompleted -= Jump;
    }

    private void Jump()
    {
        transform.DOJump(_endPoint.position, 1, 1, 2, false).SetAutoKill(true);
        transform.DORotate(new Vector3(0, 15, 0), 1, RotateMode.Fast).SetAutoKill(true);
    }
}
