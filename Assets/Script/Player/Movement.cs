using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 1;
    [SerializeField] private float _jumpForce = 5;

    private float _horizontalMove;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isGround = true;
    private Death _death;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _death = GetComponent<Death>();
    }

    private void Update()
    {
        if (!_death.DeathPlayer)
        {
            _horizontalMove = Input.GetAxis("Horizontal") * _runSpeed * Time.deltaTime;
            _rigidbody2D.position += new Vector2(_horizontalMove, 0);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                Jump();
            }
        }

        Flip();
        SwitchAnimation();
    }

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void SwitchAnimation()
    {
        if (_horizontalMove == 0)
        {
            _animator.SetBool("Run", false);
        }
        else
        {
            _animator.SetBool("Run", true);
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            _isGround = true;
        }

        if (collision.gameObject.GetComponent<Coin>())
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            _isGround = false;
        }
    }
}
