using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Mesh))]

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private HandleAnimator handleAnimator;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _swordFront;
    [SerializeField] private float _moveSpeed;

    private readonly float _maxX = 0.95f;
    private readonly float _maxSpeed = 5.1f;
    private readonly float _slowMoveSpeed = 0.6f;

    private Vector2 _moveDirection;
    private float _defaultSpeed;
    private bool _canMove = true;
    private bool _isButtonPressed = false;
    private int _direction;
    private MeshRenderer _mesh;

    public float FastSpeed { get; private set; } = 3;

    public float SlowSpeed { get; private set; } = 0.8f;

    private void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _defaultSpeed = _moveSpeed;
    }

    private void Update()
    {
        if (_canMove)
        {
            if (_isButtonPressed)
                MovePlatform(_direction);
            else
                Move(_moveDirection);

            EnableSwordXLimit();
        }

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _target.position.y, _target.position.z), Time.deltaTime * _speed);
    }

    private void EnableSwordXLimit()
    {
        if (transform.position.x > _maxX)
            transform.position = new Vector3(transform.position.x - (_moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        else if(transform.position.x < -_maxX)
            transform.position = new Vector3(transform.position.x + (_moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
    }

    private void MovePlatform(int direction)
    {
        transform.position = new Vector3(transform.position.x + (_moveSpeed * Time.deltaTime * _direction), transform.position.y, transform.position.z);
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, direction.y);

        transform.position += moveDirection * scaledMoveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    public void OnLeftMoveButton(bool isMove)
    {
        _direction = -1;
        _isButtonPressed = isMove;
    }

    public void OnRightMoveButton(bool isMove)
    {
        _direction = 1;
        _isButtonPressed = isMove;
    }

    public void SetSpeed(float speed)
    {
        if (speed > 0 && speed <= _maxSpeed)
            _speed = speed;
    }

    public void RotateSword(float angel)
    {
        transform.DORotate(new Vector3(0, angel, 0), 0.6f * Time.timeScale, RotateMode.WorldAxisAdd);
    }

    public void SetSlowMoveSpeed() 
    {
        _moveSpeed = _slowMoveSpeed;
    }

    public void SetDefaultMoveSpeed()
    {
        _moveSpeed = _defaultSpeed;
    }

    public void SetDefaultPosition()
    {
        transform.DORotate(new Vector3(0, 0, 0), 0.6f, RotateMode.Fast);

    }

    public void SetToMiddle()
    {
        transform.DOMoveX(0, 0.4f);
    }

    public void DisableMove()
    {
        _canMove = false;
    }

    public void EnableMove()
    {
        _canMove = true;
    }
}
