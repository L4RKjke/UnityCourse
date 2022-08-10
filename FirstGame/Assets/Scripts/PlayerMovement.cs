using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool _isGraunded = true;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


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
        CheckGround();

        if (Input.GetKeyDown(KeyCode.Space) && _isGraunded)
        {
            _animator.SetTrigger("jump");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
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

    private void CheckGround()
    {
        _isGraunded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadious, _ground);
    }
}