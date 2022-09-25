using UnityEngine;

public class WalkState : State  
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private const string _isWalking = "IsWalking";

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (Target != null)
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(_isWalking, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(_isWalking, false);
    }
}