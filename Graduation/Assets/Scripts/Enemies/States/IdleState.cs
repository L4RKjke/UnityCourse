using UnityEngine;

public class IdleState : State
{
    [SerializeField] private Animator _animator;

    private readonly string _isIdle = "IsIdle";

    private void Start()
    {
        _animator.SetBool(_isIdle, true);
    }
}
