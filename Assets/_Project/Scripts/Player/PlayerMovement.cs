using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Animator animator;

    [SerializeField] private float _movementSpeed = 5f;


    //private Vector2 _movement;
    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + _direction * _movementSpeed * Time.deltaTime);
    }

    public void StopMove()
    {
        _direction = Vector2.zero;
    }

    public void HandleMove(Vector2 vector, bool dash)
    {
        HandleMove(vector.x, vector.y, dash);
    }

    public void HandleMove(float x, float y, bool dash)
    {
        _direction.x = x;
        _direction.y = y;

        AnimateMove();

        if (_direction != new Vector2(0, 0))
        {
            ChangeAnimationDir();
        }
    }

    private void AnimateMove()
    {
        animator.SetFloat("Horizontal", _direction.x);
        animator.SetFloat("Vertical", _direction.y);
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    private void ChangeAnimationDir()
    {
        //_direction = _movement;
        animator.SetFloat("Dir_Horizontal", _direction.x);
        animator.SetFloat("Dir_Vertical", _direction.y);
    }
}
