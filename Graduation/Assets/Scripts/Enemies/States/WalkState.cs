using UnityEngine;

public class WalkState : State  
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemy;

    private Animator _animator;

    private readonly string _isWalking = "IsWalking";

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (Target != null)
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, Target.transform.position, _speed * Time.deltaTime);
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