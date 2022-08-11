using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] 
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _checkRadious = 0.02f;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private Transform BulletGenerator;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private const string _jumpTrigger = "jump";
    private const string _isRunning = "isRunning";


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Run();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            _animator.SetTrigger(_jumpTrigger);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            _animator.SetBool(_isRunning, true);
        }
        else
        {
            _animator.SetBool(_isRunning, false);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = true;
        }
    }

    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkRadious, _ground);
    }
}