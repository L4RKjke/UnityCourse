using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Transform))]

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private PlayerBullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootingRate;
    [SerializeField] private int _health;
    [SerializeField] private SpriteRenderer _muzzle;
    [SerializeField] private Animator _muzzleAnimaror;

    private Transform _transform;
    private Vector2 _coursorPosition;
    private Vector2 _defoaltcale;
    private Vector2 _invertedScale;
    private bool _isFire;
    private bool _canShoot;

    private readonly string _shoot = "Shoot";
    private readonly string _waitForDelay = "WaitForDelay";

    public delegate void PlayerHealthEvent(float argument);

    public event PlayerHealthEvent PlayerChangeHealth;

    public UnityAction PlayerDie;

    public int Health => _health; 

    public Transform Transform => _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _invertedScale = new Vector2(-_transform.localScale.x, _transform.localScale.y);
        _defoaltcale = new Vector2(_transform.localScale.x, _transform.localScale.y);
        _canShoot = true;
        StartCoroutine(_waitForDelay);
    }

    private void OnDisable()
    {
        StopCoroutine(_waitForDelay);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {    
        if (context.performed || context.started)
            _isFire = true;
        else
            _isFire = false;
    }

    public void OnMouseMoving(InputAction.CallbackContext context)
    {
        _coursorPosition = _camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void Update()
    {
        if (_isFire && _canShoot)
        {
            if (_coursorPosition.x - _shootPoint.position.x < 0)
                Shoot(GetAngle(_coursorPosition) + 180);
            else
                Shoot(GetAngle(_coursorPosition));

            _canShoot = false;
        }

        SetCrosshairPosition(_coursorPosition);
        RotateWeapon();

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

        if (_health == 0)
        {
            PlayerDie?.Invoke();
            Destroy(gameObject);
        }
    }

    private void RotateWeapon()
    {
        if (Vector2.Distance(_weapon.transform.position, _coursorPosition) > 1f)
            _weapon.transform.rotation = Quaternion.Euler(0f, 0f, GetAngle(_coursorPosition));
    }

    private void SetCrosshairPosition(Vector2 position) 
    {
        _crosshair.transform.position = position;
    }

    private float GetAngle(Vector2 crosshairPosition) => (180 / Mathf.PI) * 
        Mathf.Atan((crosshairPosition.y - _shootPoint.position.y) / (crosshairPosition.x - _shootPoint.position.x));

    private void Shoot(float direction) 
    {
        _muzzleAnimaror.SetTrigger(_shoot);
        Instantiate(_bullet, _shootPoint.position, Quaternion.Euler(new Vector3(0, 0, direction)));
    }

    private IEnumerator WaitForDelay()
    {
        while (true)
        {
            _canShoot = true;

            yield return new WaitForSeconds(_shootingRate);
        }            
    }
}