using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private PlayerBullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootingRate;
    [SerializeField] private int _health;
    [SerializeField] private SpriteRenderer _muzzle;
    [SerializeField] private Animator _muzzleAnimaror;
    [SerializeField] private GameObject _pauseMenu;

    private AudioSource _audioSource;
    private Transform _transform;
    private Vector2 _moveDirection;
    private Vector2 _coursorPosition;
    private Animator _animator;
    private const string _isWalking = "IsWalking";
    private const string _shoot = "Shoot";
    private Vector2 _defoaltcale;
    private Vector2 _invertedScale;
    private bool _isFire;
    private float _timer;

    public delegate void PlayerHealthEvent(float argument);

    public event PlayerHealthEvent PlayerChangeHealth;

    public int Health => _health;

    public Transform Transform => _transform;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _invertedScale = new Vector2(-_transform.localScale.x, _transform.localScale.y);
        _defoaltcale = new Vector2(_transform.localScale.x, _transform.localScale.y);
        _timer = _shootingRate;
        _pauseMenu.SetActive(false);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {    
        if (context.performed || context.started)
        {
            _isFire = true;
        }
        else
        {
            _isFire = false;
        }   

    }

    public void OnPauseMenu(InputAction.CallbackContext context)
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnMouseMoving(InputAction.CallbackContext context)
    {
        _coursorPosition = _camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        if (_timer > 0)
            _timer -= Time.deltaTime;

        if (_isFire && _timer < 0.01f)
        {
            _timer = _shootingRate;

            if (_coursorPosition.x - _shootPoint.position.x < 0)
                Shoot(GetAngle(_coursorPosition) + 180);
            else
                Shoot(GetAngle(_coursorPosition));
        }

        Move(_moveDirection);
        SetCrosshairPosition(_coursorPosition);

        if (Vector2.Distance(_weapon.transform.position, _coursorPosition) > 1f)
            _weapon.transform.rotation = Quaternion.Euler(0f, 0f, GetAngle(_coursorPosition));

        if (_coursorPosition.x > transform.position.x)
            _transform.localScale = _defoaltcale;      
        else
            _transform.localScale = _invertedScale;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            Debug.Log("damage should be possitive number!");

        if (_health > 0)
            _health -= damage;

        PlayerChangeHealth?.Invoke(_health);
    }

    public void Move(Vector2 direction)
    {
        _animator.SetBool(_isWalking, true);

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        if (direction.y == 0 && direction.x == 0)
            _animator.SetBool(_isWalking, false);

        Vector3 moveDirection = new Vector3(direction.x, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
    }

    private void SetCrosshairPosition(Vector2 position) 
    {
        _crosshair.transform.position = position;
    }

    private float GetAngle(Vector2 crosshairPosition) => (180 / Mathf.PI) * Mathf.Atan((crosshairPosition.y - _shootPoint.position.y) / (crosshairPosition.x - _shootPoint.position.x));

    private void Shoot(float direction) 
    {
        _muzzleAnimaror.SetTrigger(_shoot);
        _audioSource.Play(0);
        Instantiate(_bullet, _shootPoint.position, Quaternion.Euler(new Vector3(0, 0, direction)));
    }
}