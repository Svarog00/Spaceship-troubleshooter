using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _movementSpeed = 5f;

    private Vector2 _direction;
    private bool _faceRight;

    private static readonly int WalkHashAnimation = Animator.StringToHash("Walk");
    private static readonly int IdleHashAnimation = Animator.StringToHash("Idle");

    private void FixedUpdate()
    {
        _rb2.MovePosition(_rb2.position + _direction * _movementSpeed * Time.deltaTime);
    }

    public void StopMove()
    {
        _direction = Vector2.zero;
        AnimateMove();
    }

    public void HandleMove(Vector2 vector)
    {
        HandleMove(vector.x, vector.y);
    }

    public void HandleMove(float x, float y)
    {
        _direction.x = x;
        _direction.y = y;

        AnimateMove();

        if (_direction != new Vector2(0, 0))
        {
            SetSpriteDirection(_direction);
            return;
        }
    }

    private void AnimateMove()
    {
        _animator.CrossFade(GetMovementState(), 0f);
    }

    private int GetMovementState()
    {
        return _direction != Vector2.zero ? WalkHashAnimation : IdleHashAnimation;
    }

    public void SetSpriteDirection(Vector2 direction)
    {
        _direction = direction;
        if (_direction.x > 0 && _faceRight == true)
        {
            ChangeAnimationDir();
        }
        if (_direction.x < 0 && _faceRight == false)
        {
            ChangeAnimationDir();
        }
    }

    private void ChangeAnimationDir()
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = gameObject.transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
