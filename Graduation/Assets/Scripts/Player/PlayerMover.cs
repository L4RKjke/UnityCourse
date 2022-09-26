using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _animator;

    private Vector2 _moveDirection;

    private readonly string _isWalking = "IsWalking";
    private readonly Transform _transform;

    public float Speed => _moveSpeed;

    public Transform Transform => _transform;

    private void Update()
    {
        Move(_moveDirection);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        _animator.SetBool(_isWalking, true);

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        if (direction.y == 0 && direction.x == 0)
            _animator.SetBool(_isWalking, false);

        Vector3 moveDirection = new Vector3(direction.x, direction.y);
        _player.transform.position += moveDirection * scaledMoveSpeed;
    }
}