using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StateSwitcher))]
[RequireComponent(typeof(TransitionAtackToWalk))]
[RequireComponent(typeof(TransitionWalkToAtack))]
[RequireComponent(typeof(TransitionToIdle))]
[RequireComponent(typeof(AtackState))]
[RequireComponent(typeof(WalkState))]
[RequireComponent(typeof(IdleState))]

public class EnemyRed : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private int _shotDeley;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private Transform _shootPoint;

    private Player _player;
    private float _timer;
    private bool _isFire = false;
    private Vector2 _defoaltScale;
    private Vector2 _invertedScale;
    private Transform _transform;
    private Animator _animator;

    private readonly float _shootingRate = 1;
    private readonly string _isShooting = "IsShooting";
    private readonly Transform _targetTransform;

    public Transform EnemyTransform => _transform;

    public Player Target => _player;

    public Transform TargetTransform => _targetTransform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _invertedScale = new Vector2(-_transform.localScale.x, _transform.localScale.y);
        _defoaltScale = new Vector2(_transform.localScale.x, _transform.localScale.y);
    }

    private void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;

        if (_isFire && _timer < 0.01f)
        {
            _timer = _shootingRate;

            if (Target.transform.position.x - _shootPoint.position.x < 0)
                Shoot(GetAngle(Target.transform.position, _shootPoint.position) + 180);
            else
                Shoot(GetAngle(Target.transform.position, _shootPoint.position));
        }

        if (Target != null)
        {
            if (Target.transform.position.x > transform.position.x)
                _transform.localScale = _invertedScale;
            else
                _transform.localScale = _defoaltScale;
        }
    }

    override public void StartShooting()
    {
        _isFire = true;
        _animator.SetBool(_isShooting, true);
    }

    override public void StopShooting()
    {
        _isFire = false;
        _animator.SetBool(_isShooting, false);
    }

    private float GetAngle(Vector2 targetPosition, Vector2 startPosition) => (180 / Mathf.PI) *
        Mathf.Atan((targetPosition.y - startPosition.y) / (targetPosition.x - startPosition.x));

    private void Shoot(float direction)
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.Euler(new Vector3(0, 0, direction)));
    }

    public void Init(Player target)
    {
        _player = target;
    }
}